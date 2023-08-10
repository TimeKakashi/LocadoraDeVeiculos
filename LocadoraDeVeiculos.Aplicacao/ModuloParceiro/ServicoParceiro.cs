using FluentResults;
using LocadoraDeVeiculos.Aplicacao.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using Serilog;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Aplicacao.ModuloParceiro
{
    public class ServicoParceiro : ServicoBase<Parceiro>
    {
        public IRepositorioParceiro repositorioParceiro;
        public IValidadorParceiro validadorParceiro;
        public ServicoParceiro(IRepositorioParceiro repositorioParceiro, IValidadorParceiro validadorparceiro)
        {
            this.repositorioParceiro = repositorioParceiro;
            this.validadorParceiro = validadorparceiro;
        }

        public override Result Editar(Parceiro registro)
        {
            Log.Debug("Tentando editar parceiro...{@d}", registro);

            List<string> erros = ValidarRegistro(registro);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioParceiro.Editar(registro);

                Log.Debug("Parceiro {ParceiroId} editada com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar parceiro.";

                Log.Error(exc, msgErro + "{@d}", registro);

                return Result.Fail(msgErro);
            }
        }

        public override Result Excluir(Parceiro registro)
        {
            Log.Debug("Tentando excluir parceiro...{@d}", registro);

            try
            {
                bool parceiroExiste = repositorioParceiro.Existe(registro);

                if (parceiroExiste == false)
                {
                    Log.Warning("Parceiro {ParceiroId} não encontrada para excluir", registro.Id);

                    return Result.Fail("Parceiro não encontrada");
                }

                repositorioParceiro.Excluir(registro);

                Log.Debug("Parceiro {ParceiroId} excluída com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                List<string> erros = new List<string>();

                string msgErro;

                if (ex.Message.Contains("FK_TBMateria_TBParceiro"))
                    msgErro = "Esta parceiro está relacionada com uma matéria e não pode ser excluída";
                else
                    msgErro = "Falha ao tentar excluir parceiro";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {ParceiroId}", registro.Id);

                return Result.Fail(erros);
            }
        }

        public override Result Inserir(Parceiro registro)
        {
            Log.Debug("Tentando inserir parceiro...{@d}", registro);

            List<string> erros = ValidarRegistro(registro);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            if (NomeDuplicado(registro))
                return Result.Fail($"Este nome '{registro.Nome}' já está sendo utilizado");

            try
            {
                repositorioParceiro.Inserir(registro);

                Log.Debug("Parceiro {ParceiroId} inserida com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir parceiro.";

                Log.Error(exc, msgErro + "{@d}", registro);

                return Result.Fail(msgErro);
            }
        }

        protected override List<string> ValidarRegistro(Parceiro registro)
        {
            var resultadoValidacao = validadorParceiro.Validate(registro);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(registro))
                erros.Add($"Este nome '{registro.Nome}' já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;

        }

        private bool NomeDuplicado(Parceiro registro)
        {
            Parceiro parceiroEncontrado = repositorioParceiro.SelecionarPorNome(registro.Nome);

            if (parceiroEncontrado != null &&
                parceiroEncontrado.Id != registro.Id &&
                parceiroEncontrado.Nome == registro.Nome)
            {
                return true;
            }

            return false;
        }

    }
}
