using FluentResults;
using LocadoraDeVeiculos.Aplicacao.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
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
        IRepositorioAluguel repositorioAluguel;
        IValidadorAluguel validadorAluguel;

        public ServicoAluguel(IRepositorioAluguel repositorioAluguel, IValidadorAluguel validadorAluguel)
        {
            this.repositorioAluguel = repositorioAluguel;
            this.validadorAluguel = validadorAluguel;
        }

        public override Result Inserir(Aluguel registro)
        {
            Log.Debug("Tentando Inserir um Aluguel");

            List<string> erros = ValidarRegistro(registro);

            if (erros.Count > 0)
                return Result.Fail(erros);
            try
            {
                repositorioAluguel.Inserir(registro);

                Log.Debug("Alguel inserido com sucesso!");

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
                return Result.Fail(erros);
            try
            {
                repositorioAluguel.Editar(registro);

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

            if(registro.Finalizado == false)
            {
                Log.Warning("Tentativa de exclusao de alguel em andamento!");

                return Result.Fail("Veiculo tem um aluguel em andamento!");
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

                Log.Debug("veiculo {Alugelid} excluído com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
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

            foreach (string erro in erros)
                Log.Warning(erro);

            return erros;
        }
    }
}
