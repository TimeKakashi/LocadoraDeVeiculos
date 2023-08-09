using FluentResults;
using LocadoraDeVeiculos.Aplicacao.Compartilhado;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloCupom
{
    public class ServicoCupom : ServicoBase<Cupom>
    {
        public IRepositorioCupom repositorioCupom;
        public IValidadorCupom validadorCupom;
        private IRepositorioParceiro repositorioParceiro;
        private ValidadorCupom validadorCupom1;
        private IContextoPersistencia contextoPersistencia;

        public ServicoCupom(IRepositorioCupom repositorioCupom, IValidadorCupom validadorcupom, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioCupom = repositorioCupom;
            this.validadorCupom = validadorcupom;
            this.contextoPersistencia = contextoPersistencia;
        }

        public ServicoCupom(IRepositorioParceiro repositorioParceiro, ValidadorCupom validadorCupom1)
        {
            this.repositorioParceiro = repositorioParceiro;
            this.validadorCupom1 = validadorCupom1;
        }

        public override Result Editar(Cupom registro)
        {
            Log.Debug("Tentando editar cupom...{@d}", registro);

            List<string> erros = ValidarRegistro(registro);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioCupom.Editar(registro);

                contextoPersistencia.GravarDados();

                Log.Debug("Cupom {CupomId} editada com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar cupom.";

                Log.Error(exc, msgErro + "{@d}", registro);

                return Result.Fail(msgErro);
            }
        }

        public override Result Excluir(Cupom registro)
        {
            Log.Debug("Tentando excluir cupom...{@d}", registro);

            try
            {
                bool parceiroExiste = repositorioCupom.Existe(registro);

                if (parceiroExiste == false)
                {
                    Log.Warning("Cupom {CupomId} não encontrada para excluir", registro.Id);

                    return Result.Fail("Cupom não encontrado");
                }

                repositorioCupom.Excluir(registro);

                contextoPersistencia.GravarDados();

                Log.Debug("Cupom {CupomId} excluída com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                List<string> erros = new List<string>();

                string msgErro;

                if (ex.Message.Contains("FK_TBMateria_TBParceiro"))
                    msgErro = "Esta cupom está relacionada com um cliente e não pode ser excluída";
                else
                    msgErro = "Falha ao tentar excluir cupom";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {CupomId}", registro.Id);

                return Result.Fail(erros);
            }
        }

        public override Result Inserir(Cupom registro)
        {
            Log.Debug("Tentando inserir cupom...{@d}", registro);

            List<string> erros = ValidarRegistro(registro);

            if (erros.Count() > 0) 
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioCupom.Inserir(registro);

                contextoPersistencia.GravarDados();

                Log.Debug("Cupom {ParceiroId} inserida com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir cupom.";

                Log.Error(exc, msgErro + "{@d}", registro);

                return Result.Fail(msgErro);
            }
        }

        protected override List<string> ValidarRegistro(Cupom registro)
        {
            var resultadoValidacao = validadorCupom.Validate(registro);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(registro))
                erros.Add($"Este cupom '{registro.Nome}' já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;

        }
        protected override bool NomeDuplicado (Cupom cupom)
        {
            Cupom cupomEncontrado = repositorioCupom.SelecionarPorNome(cupom.Nome);
            if (cupomEncontrado != null &&
            cupomEncontrado.Id != cupom.Id &&
                cupomEncontrado.Nome == cupom.Nome)
            {
                return true;
            }
            else
                return false;
        }
    }
}
