using FluentResults;
using LocadoraDeVeiculos.Dominio.Combustivel;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using Serilog;
using FluentValidation.Results;


namespace LocadoraDeVeiculos.Aplicacao.ModuloCombustivel
{
    public class ServicoCombustivel
    {
        IRepositorioCombustivelJson repositorioCombustivelJson;
        IValidadorCombustivel validadorCombustivel;
        public ServicoCombustivel(IRepositorioCombustivelJson repositorioCombustivelJson, IValidadorCombustivel validadorCombustivel)
        {
            this.repositorioCombustivelJson = repositorioCombustivelJson;
            this.validadorCombustivel = validadorCombustivel;
        }
        public Result EditarValores(List<decimal> combustiveis)
        {
            Log.Debug("Tentando editar cliente...");

            List<string> erros = ValidarCliente(combustivel);

            if (erros.Count > 0)
                return Result.Fail(erros);

            try
            {
                repositorioCombustivelJson.EditarValores(combustivel);

                Log.Debug("Cliente {ClienteId} editado com sucesso", combustivel.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar cliente.";

                Log.Error(exc, msgErro + "{@c}", combustivel);

                return Result.Fail(msgErro);
            }
        }

        private List<string> ValidarCliente(Combustivel combustivel)
        {
            ValidationResult resultValidation = validadorCliente.Validate(combustivel);

            var erros = new List<string>();

            if (resultValidation != null)
                erros.AddRange(resultValidation.Errors.Select(e => e.ErrorMessage));

            if (NomeDuplicado(combustivel))
                erros.Add($"Esse nome: '{combustivel.Nome}' já está em uso!");

            foreach (string erro in erros)
                Log.Warning(erro);

            return erros;
        }
    }


}
