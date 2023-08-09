using FluentResults;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using Serilog;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCombustivel;
using System.Security.Cryptography.X509Certificates;

namespace LocadoraDeVeiculos.Aplicacao.ModuloCombustivel
{
    public class ServicoCombustivel
    {
        private IRepositorioCombustivelJson repositorioCombustivelJson;
        private IValidadorCombustivel validadorCombustivel;
        private IContextoPersistencia contextoPersistencia;
        public ServicoCombustivel(IRepositorioCombustivelJson repositorioCombustivelJson, IValidadorCombustivel validadorCombustivel, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioCombustivelJson = repositorioCombustivelJson;
            this.validadorCombustivel = validadorCombustivel;
            this.contextoPersistencia = contextoPersistencia;
        }
        public Result EditarValores(List<Combustivel> combustiveis)
        {
            Log.Debug("Tentando editar cliente...");

            var erros = new List<string>();

            foreach(var item in combustiveis)
            {
                if(ValidarCombustivel(item).Count() > 0)
                    foreach(var item2 in ValidarCombustivel(item))
                    { erros.Add(item2.ToString());}
            }


            if (erros.Count() > 0) 
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioCombustivelJson.EditarValores(combustiveis);

                contextoPersistencia.GravarDados();

                Log.Debug("Combustivel editado com sucesso");

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar combsutivel.";

                Log.Error(exc, msgErro + "{@c}", combustiveis);

                return Result.Fail(msgErro);
            }
        }

        private List<string> ValidarCombustivel(Combustivel combustivel)
        {
            ValidationResult resultValidation = validadorCombustivel.Validate(combustivel);

            var erros = new List<string>();

            if (resultValidation != null)
                erros.AddRange(resultValidation.Errors.Select(e => e.ErrorMessage));

            foreach (string erro in erros)
                Log.Warning(erro);

            return erros;
        }
    }


}
