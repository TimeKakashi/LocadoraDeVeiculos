using FluentResults;
using LocadoraDeVeiculos.Aplicacao.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloTaxaServico
{
    public  class ServicoTaxaServico : ServicoBase<TaxaServico>
    {
        public IRepositorioTaxaServico repositorioTaxaServico;
        public IValidadorTaxaServico validadorTaxaServico;
      

        public ServicoTaxaServico(IRepositorioTaxaServico repositorioTaxaServico, IValidadorTaxaServico validadorTaxaServico) 
        {   
            this.repositorioTaxaServico = repositorioTaxaServico;
            this.validadorTaxaServico=validadorTaxaServico;
        }

        public override Result Editar(TaxaServico registro)
        {
            Log.Debug("Tentando editar taxaServiço...{@d}", registro);

            List<string> erros = ValidarRegistro(registro);

            if (erros.Count > 0)
                return Result.Fail(erros); 


            try
            {
                repositorioTaxaServico.Editar(registro);

                Log.Debug("TaxaServiço {TaxaServicoId} editada com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar taxaServiço.";

                Log.Error(exc, msgErro + "{@d}", registro);

                return Result.Fail(msgErro);
            }
        }

        public override Result Excluir(TaxaServico registro)
        {
            Log.Debug("Tentando excluir taxaServiço...{@d}", registro);
            try
            {
                bool parceiroExiste = repositorioTaxaServico.Existe(registro);

                if (parceiroExiste == false)
                {
                    Log.Warning("TaxaServico {TaxaServicoId} não encontrada para excluir", registro.Id);

                    return Result.Fail("TaxaServico não encontrado");
                }

                repositorioTaxaServico.Excluir(registro);

                Log.Debug("TaxaServico {TaxaServicoId} excluída com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                List<string> erros = new List<string>();

                string msgErro;

                if (ex.Message.Contains("FK_TBMateria_TBParceiro"))
                    msgErro = "Esta TaxaServico está relacionada com um cliente e não pode ser excluída";
                else
                    msgErro = "Falha ao tentar excluir taxaServico";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {TaxaServicoId}", registro.Id);

                return Result.Fail(erros);
            }
        }

        public override Result Inserir(TaxaServico registro)
        {
            Log.Debug("Tentando inserir TaxaServico...{@d}", registro);

            List<string> erros = ValidarRegistro(registro);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioTaxaServico.Inserir(registro);

                Log.Debug("TaxaServiço {TaxaServicoId} inserida com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir taxaServico.";

                Log.Error(exc, msgErro + "{@d}", registro);

                return Result.Fail(msgErro);
            }
        }

        protected override List<string> ValidarRegistro(TaxaServico registro)
        {
            var resultadoValidacao = validadorTaxaServico.Validate(registro);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(registro))
                erros.Add($"Esta TaxaServico '{registro.Nome}' já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }
    }
}
