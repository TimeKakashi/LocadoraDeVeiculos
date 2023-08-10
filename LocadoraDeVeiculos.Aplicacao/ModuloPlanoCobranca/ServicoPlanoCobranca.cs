using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Aplicacao.Compartilhado;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using Org.BouncyCastle.Math.EC.Rfc7748;
using Serilog;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Aplicacao.ModuloPlanoCobranca
{
    public class ServicoPlanoCobranca : ServicoBase<PlanoCobranca>
    {
        private IRepositorioPlanoCobranca repositorioPlanoCobranca;
        private IReposisotiroGrupoAutomovel reposisotiroGrupoAutomovel;
        private IContextoPersistencia contextoPersistencia;

        private IValidadorPlanoCobranca validadorPlano;

        public ServicoPlanoCobranca(IRepositorioPlanoCobranca repositorioPlanoCobranca, IReposisotiroGrupoAutomovel reposisotiroGrupoAutomovel, IValidadorPlanoCobranca validadorPlano, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
            this.validadorPlano = validadorPlano;
            this.reposisotiroGrupoAutomovel = reposisotiroGrupoAutomovel;
            this.contextoPersistencia = contextoPersistencia;
        }

        public override Result Inserir(PlanoCobranca plano)
        {
            Log.Debug("Tentando Inserir um plano");

            List<string> erros = ValidarRegistro(plano);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioPlanoCobranca.Inserir(plano);

                contextoPersistencia.GravarDados();

                Log.Debug("plano inserido com sucesso!");

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msg = "Falha ao tentar inserir plano!";

                Log.Error(ex, msg + "{@f}", plano);

                return Result.Fail(msg);
            }
        }

        public override Result Editar(PlanoCobranca plano)
        {
            Log.Debug("Tentando editar plano...{@d}", plano);

            List<string> erros = ValidarRegistro(plano);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioPlanoCobranca.Editar(plano);

                contextoPersistencia.GravarDados();

                Log.Debug("plano {planoId} editado com sucesso", plano.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar plano.";

                Log.Error(exc, msgErro + "{@d}", plano);

                return Result.Fail(msgErro);
            }
        }

        public override Result Excluir(PlanoCobranca plano)
        {
            Log.Debug("Tentando excluir plano...{@d}", plano);

            try
            {
                bool funcExiste = repositorioPlanoCobranca.Existe(plano);

                if (funcExiste == false)
                {
                    Log.Warning("plano {planoId} não encontrado para excluir", plano.Id);

                    return Result.Fail("funcionario não encontrado");
                }

                if(plano.GrupoAutomovel.Veiculos.Count > 0)
                {
                    Log.Warning("Falha ao excluir plnao{p.id}", plano.Id);

                    return Result.Fail("plano plano está ligado a um automovel e não é possível excluir");
                }

                repositorioPlanoCobranca.Excluir(plano);

                contextoPersistencia.GravarDados();

                Log.Debug("plano {planoId} excluído com sucesso", plano.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                List<string> erros = new List<string>();

                string msgErro;

                if (ex.Message.Contains("FK_TBPlanoCobranca_TBGrupoAutomovel"))
                    msgErro = "Este plano está relacionada com um grupo de automovel e não pode ser excluído";
                else
                    msgErro = "Falha ao tentar excluir plano";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {planoId}", plano.Id);

                return Result.Fail(erros);
            }
        }

        protected override List<string> ValidarRegistro(PlanoCobranca plano)
        {
            ValidationResult resultValidation = validadorPlano.Validate(plano);

            var erros = new List<string>();

            var grupo = reposisotiroGrupoAutomovel.SelecionarPorNome(plano.GrupoAutomovel.Nome);

            if (grupo.Planos.Any(x => x.Plano == plano.Plano))
                erros.Add($"Este Grupo de Automovel ja possui um {plano.Plano}");

            if (resultValidation != null)
                erros.AddRange(resultValidation.Errors.Select(e => e.ErrorMessage));

            foreach (string erro in erros)
                Log.Warning(erro);

            return erros;
        }
    }
}
