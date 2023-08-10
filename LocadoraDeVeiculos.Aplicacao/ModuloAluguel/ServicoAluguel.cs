using FluentResults;
using LocadoraDeVeiculos.Aplicacao.Compartilhado;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCombustivel;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloAluguel
{
    public class ServicoAluguel : ServicoBase<Aluguel>
    {
        private IRepositorioAluguel repositorioAluguel;
        private IRepositorioCupom repositorioCupom;
        private IRepositorioCombustivelJson repositorioCombustivelJson;
        private IValidadorAluguel validadorAluguel;
        private IContextoPersistencia contextoPersistencia;


        public ServicoAluguel(IRepositorioAluguel repositorioAluguel, IRepositorioCupom repositorioCupom,IRepositorioCombustivelJson repositorioCombustivelJson ,IValidadorAluguel validadorAluguel, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioAluguel = repositorioAluguel;
            this.validadorAluguel = validadorAluguel;
            this.repositorioCupom = repositorioCupom;
            this.repositorioCombustivelJson = repositorioCombustivelJson;
            this.contextoPersistencia = contextoPersistencia;
        }

        public override Result Inserir(Aluguel registro)
        {
            Log.Debug("Tentando Inserir um Aluguel");

            List<string> erros = ValidarRegistro(registro);

            if (erros.Count() > 0) 
            { 
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }
            try
            {
                repositorioAluguel.Inserir(registro);

                contextoPersistencia.GravarDados();

                Log.Debug("Aluguel {AluguelId} inserida com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msg = "Falha ao tentar inserir um Aluguel!";

                Log.Error(ex, msg + "{@f}", registro);

                return Result.Fail(msg);
            }
        }

        public override Result Editar(Aluguel registro)
        {
            Log.Debug("Tentando editar Aluguel...{@d}", registro.Id);

            List<string> erros = ValidarRegistro(registro);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }
            try
            {
                repositorioAluguel.Editar(registro);

                contextoPersistencia.GravarDados();

                Log.Debug("veiculo {AlguelId} editado com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar Alguel.";

                Log.Error(exc, msgErro + "{@d}", registro);

                return Result.Fail(msgErro);
            }
        }

        public override Result Excluir(Aluguel registro)
        {
            Log.Debug("Tentando excluir um aluguel...{@d}", registro);

            if(registro.Finalizado == true)
            {
                Log.Warning("Tentativa de exclusao de alguel em andamento!");

                return Result.Fail("Este aluguel ja foi finalizado eh nao eh possivel exclui-lo");
            }

            try
            {
                bool alguelExiste = repositorioAluguel.Existe(registro);

                if (alguelExiste == false)
                {
                    Log.Warning("aluguel {aluguelId} não encontrado para excluir", registro.Id);

                    return Result.Fail("veiculo não encontrado");
                }

                repositorioAluguel.Excluir(registro);

                contextoPersistencia.GravarDados();

                Log.Debug("veiculo {Alugelid} excluído com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                List<string> erros = new List<string>();

                string msgErro = "Falha ao tentar excluir veiculo";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {aluguelId}", registro.Id);

                return Result.Fail(erros);
            }
        }

        protected override List<string> ValidarRegistro(Aluguel registro)
        {
            var validatonResult = validadorAluguel.Validate(registro);

            var erros = new List<string>();

            if (validatonResult != null)
                erros.AddRange(validatonResult.Errors.Select(x => x.ErrorMessage));

            if (registro.Condutor != null)
                if (registro.Condutor.ValidadeCNH < DateTime.Today)
                    erros.Add("A CNH do concutore está vencida!");

            foreach (string erro in erros)
                Log.Warning(erro);

            return erros;
        }

        public Cupom? ProcurarCupom(string txt)
        {
            return repositorioCupom.SelecionarPorNome(txt);
        }

        public decimal PegarValorGasolina(string nomeGasosa)
        {
            List<Combustivel> combustivels = repositorioCombustivelJson.SelecionarTodos();

            if (nomeGasosa == "Gasolina")
                return combustivels[0].valor;

            else if (nomeGasosa == "Alcool")
                return combustivels[1].valor;

            else if (nomeGasosa == "Gás")
                return combustivels[2].valor;

            else if (nomeGasosa == "Disel")
                return combustivels[3].valor;

            return 0;
        }
    }
}
