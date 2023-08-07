using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using Serilog;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Aplicacao.ModuloCliente
{
    public class ServicoCliente
    {
        private IRepositorioCliente repositorioCliente;
        private IValidadorCliente validadorCliente;

        public ServicoCliente(IRepositorioCliente repositorioCliente, IValidadorCliente validadorCliente)
        {
            this.repositorioCliente = repositorioCliente;
            this.validadorCliente = validadorCliente;
        }

        public Result Inserir(Cliente cliente)
        {
            Log.Debug("Tentando inserir um cliente");

            List<string> erros = ValidarCliente(cliente);

            if (erros.Count > 0)
                return Result.Fail(erros);

            try
            {
                repositorioCliente.Inserir(cliente);

                Log.Debug("Cliente inserido com sucesso!");

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msg = "Falha ao tentar inserir cliente!";

                Log.Error(ex, msg + "{@c}", cliente);

                return Result.Fail(msg);
            }
        }

        public Result Editar(Cliente cliente)
        {
            Log.Debug("Tentando editar cliente...{@c}", cliente);

            List<string> erros = ValidarCliente(cliente);

            if (erros.Count > 0)
                return Result.Fail(erros);

            try
            {
                repositorioCliente.Editar(cliente);

                Log.Debug("Cliente {ClienteId} editado com sucesso", cliente.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar cliente.";

                Log.Error(exc, msgErro + "{@c}", cliente);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Cliente cliente)
        {
            Log.Debug("Tentando excluir cliente...{@c}", cliente);

            try
            {
                bool clienteExiste = repositorioCliente.Existe(cliente);

                if (clienteExiste == false)
                {
                    Log.Warning("Cliente {ClienteId} não encontrado para excluir", cliente.Id);

                    return Result.Fail("Cliente não encontrado");
                }

                repositorioCliente.Excluir(cliente);

                Log.Debug("Cliente {ClienteId} excluído com sucesso", cliente.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                List<string> erros = new List<string>();

                string msgErro;

                if (ex.Message.Contains("FK_TBCliente_TBAluguel"))
                    msgErro = "Este cliente está relacionado com um aluguel e não pode ser excluído";
                else
                    msgErro = "Falha ao tentar excluir cliente";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {ClienteId}", cliente.Id);

                return Result.Fail(erros);
            }
        }

        private List<string> ValidarCliente(Cliente cliente)
        {
            ValidationResult resultValidation = validadorCliente.Validate(cliente);

            var erros = new List<string>();

            if (resultValidation != null)
                erros.AddRange(resultValidation.Errors.Select(e => e.ErrorMessage));

            if (NomeDuplicado(cliente))
                erros.Add($"Esse nome: '{cliente.Nome}' já está em uso!");

            foreach (string erro in erros)
                Log.Warning(erro);

            return erros;
        }

        private bool NomeDuplicado(Cliente cliente)
        {
            Cliente clienteEncontrado = repositorioCliente.SelecionarPorNome(cliente.Nome);

            if (clienteEncontrado != null &&
                clienteEncontrado.Id != cliente.Id &&
                clienteEncontrado.Nome == cliente.Nome)
            {
                return true;
            }
            else
                return false;
        }
    }
}

