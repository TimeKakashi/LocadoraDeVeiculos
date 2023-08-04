using FluentResults;
using LocadoraDeVeiculos.Aplicacao.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using Serilog;
using System.Data.SqlClient;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;

namespace LocadoraDeVeiculos.Aplicacao.ModuloGrupoAutomovel
{
    public class ServicoGrupoAutomovel : ServicoBase<GrupoAutomovel>
    {
        IReposisotiroGrupoAutomovel reposisotiroGrupoAutomovel;
        IValidadorGrupoAutomovel validadorGrupo;
        public ServicoGrupoAutomovel(IReposisotiroGrupoAutomovel reposisotiroGrupoAutomovel, IValidadorGrupoAutomovel validadorGrupo)
        {
            this.reposisotiroGrupoAutomovel = reposisotiroGrupoAutomovel;
            this.validadorGrupo = validadorGrupo;
        }

        public override Result Inserir(GrupoAutomovel registro)
        {
            Log.Debug("Tentando Inserir um grupo");

            List<string> erros = ValidarRegistro(registro);

            if (erros.Count > 0)
                return Result.Fail(erros);

            try
            {
                reposisotiroGrupoAutomovel.Inserir(registro);

                Log.Debug("grupo inserido com sucesso!");

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msg = "Falha ao tentar inserir grupo!";

                Log.Error(ex, msg + "{@f}", registro);

                return Result.Fail(msg);
            }
        }
        public override Result Editar(GrupoAutomovel registro)
        {
            Log.Debug("Tentando editar grupo...{@d}", registro);

            List<string> erros = ValidarRegistro(registro);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                reposisotiroGrupoAutomovel.Editar(registro);

                Log.Debug("Funcionario {grupoID} editado com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar grupo.";

                Log.Error(exc, msgErro + "{@d}", registro);

                return Result.Fail(msgErro);
            }
        }

        public override Result Excluir(GrupoAutomovel registro)
        {
            Log.Debug("Tentando excluir grupo...{@d}", registro);

            try
            {
                bool funcExiste = reposisotiroGrupoAutomovel.Existe(registro);

                if (funcExiste == false)
                {
                    Log.Warning("grupo {grupoID} não encontrado para excluir", registro.Id);

                    return Result.Fail("grupo não encontrado");
                }

                reposisotiroGrupoAutomovel.Excluir(registro);

                Log.Debug("grupo {grupoID} excluído com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                List<string> erros = new List<string>();

                string msgErro;

                if (ex.Message.Contains("FK_TBGrupoAutomovel_TBAutomovel"))
                    msgErro = "Este grupo está relacionada com um automovel e não pode ser excluído";
                else
                    msgErro = "Falha ao tentar excluir grupo";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {grupoID}", registro.Id);

                return Result.Fail(erros);
            }
        }

        protected override List<string> ValidarRegistro(GrupoAutomovel registro)
        {
            ValidationResult resultValidation = validadorGrupo.Validate(registro);

            var erros = new List<string>();

            if (resultValidation != null)
                erros.AddRange(resultValidation.Errors.Select(e => e.ErrorMessage));

            if (NomeDuplicado(registro))
                erros.Add($"Esse nome: '{registro.Nome}' já está em uso!");

            foreach (string erro in erros)
                Log.Warning(erro);

            return erros;
        }

        protected override bool NomeDuplicado(GrupoAutomovel registro)
        {
            GrupoAutomovel grupoSelecionado = reposisotiroGrupoAutomovel.SelecionarPorNome(registro.Nome);
            if (grupoSelecionado != null &&
                grupoSelecionado.Id != registro.Id &&
                grupoSelecionado.Nome == registro.Nome)
            {
                return true;
            }
            else
                return false;
        }
    }
}
