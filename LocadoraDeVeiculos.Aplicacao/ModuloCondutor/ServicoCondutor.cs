using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloCondutor
{
    public class ServicoCondutor
    {
        private IRepositorioCondutor repositorioCondutor;
        private IValidadorCondutor validadorCondutor;

        public ServicoCondutor(IRepositorioCondutor repositorioCondutor, IValidadorCondutor validadorCondutor)
        {
            this.repositorioCondutor = repositorioCondutor;
            this.validadorCondutor = validadorCondutor;
        }

        public Result Inserir(Condutor condutor)
        {
            Log.Debug("Tentando inserir um condutor");

            List<string> erros = ValidarCondutor(condutor);

            if (erros.Count > 0)
                return Result.Fail(erros);

            try
            {
                repositorioCondutor.Inserir(condutor);

                Log.Debug("Condutor inserido com sucesso!");

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msg = "Falha ao tentar inserir condutor!";

                Log.Error(ex, msg + "{@c}", condutor);

                return Result.Fail(msg);
            }
        }

        public Result Editar(Condutor condutor)
        {
            Log.Debug("Tentando editar condutor...{@c}", condutor);

            List<string> erros = ValidarCondutor(condutor);

            if (erros.Count > 0)
                return Result.Fail(erros);

            try
            {
                repositorioCondutor.Editar(condutor);

                Log.Debug("Condutor {CondutorId} editado com sucesso", condutor.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar condutor.";

                Log.Error(exc, msgErro + "{@c}", condutor);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Condutor condutor)
        {
            Log.Debug("Tentando excluir condutor...{@c}", condutor);

            try
            {
                bool condutorExiste = repositorioCondutor.Existe(condutor);

                if (condutorExiste == false)
                {
                    Log.Warning("Condutor {CondutorId} não encontrado para excluir", condutor.Id);

                    return Result.Fail("Condutor não encontrado");
                }

                bool condutorRelacionadoAluguel = VerificarCondutorRelacionadoAluguel(condutor);

                if (condutorRelacionadoAluguel)
                {
                    Log.Warning("Condutor {CondutorId} está relacionado a um aluguel e não pode ser excluído", condutor.Id);

                    return Result.Fail("Condutor está relacionado a um aluguel e não pode ser excluído");
                }

                repositorioCondutor.Excluir(condutor);

                Log.Debug("Condutor {CondutorId} excluído com sucesso", condutor.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha ao tentar excluir condutor.";

                Log.Error(ex, msgErro + "{@c}", condutor);

                return Result.Fail(msgErro);
            }
        }

        private List<string> ValidarCondutor(Condutor condutor)
        {
            ValidationResult resultValidation = validadorCondutor.Validate(condutor);

            var erros = new List<string>();

            if (resultValidation != null)
                erros.AddRange(resultValidation.Errors.Select(e => e.ErrorMessage));

            if (NomeDuplicado(condutor))
                erros.Add($"Esse nome: '{condutor.Nome}' já está em uso!");

            foreach (string erro in erros)
                Log.Warning(erro);

            return erros;
        }

        private bool NomeDuplicado(Condutor condutor)
        {
            Condutor condutorEncontrado = repositorioCondutor.SelecionarPorNome(condutor.Nome);

            if (condutorEncontrado != null &&
                condutorEncontrado.Id != condutor.Id &&
                condutorEncontrado.Nome == condutor.Nome)
            {
                return true;
            }
            else
                return false;
        }


        private bool VerificarCondutorRelacionadoAluguel(Condutor condutor)
        {
            // Implemente a lógica para verificar se o condutor está relacionado a um aluguel
            // Se estiver relacionado, retorne true; caso contrário, retorne false.
            // Exemplo:
            // return repositorioAluguel.ExisteAluguelComCondutor(condutor.Id);
            return false;
        }
    }

}
