using FluentResults;
using LocadoraDeVeiculos.Aplicacao.Compartilhado;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using Serilog;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Aplicacao.ModuloAutomovel
{
    public class ServicoAutomovel : ServicoBase<Veiculo>
    {
        private IRepositorioAutomovel repositorioAutomovel;
        private IValidadorAutomovel validadorAutomovel;
        private IContextoPersistencia contextoPersistencia;

        public ServicoAutomovel(IRepositorioAutomovel repositorioAutomovel, IValidadorAutomovel validadorAutomovel, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioAutomovel = repositorioAutomovel;
            this.validadorAutomovel = validadorAutomovel;
            this.contextoPersistencia = contextoPersistencia;
        }

        public override Result Editar(Veiculo registro)
        {
            Log.Debug("Tentando editar veiculo...{@d}", registro);

            List<string> erros = ValidarRegistro(registro);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }
            try
            {
                repositorioAutomovel.Editar(registro);

                contextoPersistencia.GravarDados();

                Log.Debug("veiculo {veiculoID} editado com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar veiculo.";

                Log.Error(exc, msgErro + "{@d}", registro);

                return Result.Fail(msgErro);
            }
        }

        public override Result Excluir(Veiculo registro)
        {
            Log.Debug("Tentando excluir disciplina...{@d}", registro);

            try
            {
                bool veiculoExiste = repositorioAutomovel.Existe(registro);

                if (veiculoExiste == false)
                {
                    Log.Warning("veiculo {veiculoId} não encontrado para excluir", registro.Id);

                    return Result.Fail("veiculo não encontrado");
                }

                repositorioAutomovel.Excluir(registro);

                contextoPersistencia.GravarDados();

                Log.Debug("veiculo {veiculoId} excluído com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                List<string> erros = new List<string>();

                string msgErro;

                if (ex.Message.Contains("FK_TBFuncionario_TBAluguel"))
                    msgErro = "Este veiculo está relacionada com um Aluguel e não pode ser excluído";
                else
                    msgErro = "Falha ao tentar excluir veiculo";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {veiculoId}", registro.Id);

                return Result.Fail(erros);
            }
        }

        public override Result Inserir(Veiculo registro)
        {
            Log.Debug("Tentando Inserir um veiculo");

            List<string> erros = ValidarRegistro(registro);

            if (erros.Count() > 0) 
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }
            try
            {
                repositorioAutomovel.Inserir(registro);

                contextoPersistencia.GravarDados();

                Log.Debug("veiculo inserido com sucesso!");

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msg = "Falha ao tentar inserir veiculo!";

                Log.Error(ex, msg + "{@f}", registro);

                return Result.Fail(msg);
            }
        }

        protected override List<string> ValidarRegistro(Veiculo registro)
        {
            var validatonResult = validadorAutomovel.Validate(registro);

            var erros = new List<string>();

            if (validatonResult != null)
                erros.AddRange(validatonResult.Errors.Select(x => x.ErrorMessage));

            foreach (string erro in erros)
                Log.Warning(erro);

            return erros;
        }
    }
}
