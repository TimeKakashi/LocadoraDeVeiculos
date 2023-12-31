﻿using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Aplicacao.Compartilhado;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using Serilog;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Aplicacao.ModuloFuncionario
{
    public class ServicoFuncionario : ServicoBase<Funcionario>
    {
        private IRepositorioFuncionario repositorioFuncionario;
        private IValidadorFuncionario validadorFuncionario;
        private IContextoPersistencia contextoPersistencia;

        public ServicoFuncionario(IRepositorioFuncionario repositorioFuncionario, IValidadorFuncionario validadorFuncionario, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioFuncionario = repositorioFuncionario;
            this.validadorFuncionario = validadorFuncionario;
            this.contextoPersistencia = contextoPersistencia;
        }

        public override Result Inserir(Funcionario funcionario)
        {
            Log.Debug("Tentando Inserir um funcionario");

            List<string> erros = ValidarRegistro(funcionario);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioFuncionario.Inserir(funcionario);

                contextoPersistencia.GravarDados();

                Log.Debug("Funcionario inserido com sucesso!");

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msg = "Falha ao tentar inserir discplina!";

                Log.Error(ex, msg + "{@f}", funcionario);

                return Result.Fail(msg);
            }
        }

        public override Result Editar(Funcionario funcionario)
        {
            Log.Debug("Tentando editar funcionario...{@d}", funcionario);

            List<string> erros = ValidarRegistro(funcionario);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioFuncionario.Editar(funcionario);

                contextoPersistencia.GravarDados();

                Log.Debug("Funcionario {FuncionarioId} editado com sucesso", funcionario.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar funcionario.";

                Log.Error(exc, msgErro + "{@d}", funcionario);

                return Result.Fail(msgErro);
            }
        }

        public override Result Excluir(Funcionario funcionario)
        {
            Log.Debug("Tentando excluir funcionario...{@d}", funcionario);

            try
            {
                bool funcExiste = repositorioFuncionario.Existe(funcionario);

                if (funcExiste == false)
                {
                    Log.Warning("funcionario {funcionarioId} não encontrado para excluir", funcionario.Id);

                    return Result.Fail("funcionario não encontrado");
                }

                repositorioFuncionario.Excluir(funcionario);

                Log.Debug("funcionario {funcionarioId} excluído com sucesso", funcionario.Id);

                contextoPersistencia.GravarDados();

                return Result.Ok();
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                List<string> erros = new List<string>();

                string msgErro;

                if(ex.InnerException != null)
                {
                    if (ex.InnerException.Message.Contains("FK_TBAluguel_TBFuncionario"))
                        msgErro = "Este funcionario está relacionada com um aluguel e não pode ser excluído";
                    else
                        msgErro = "Falha ao tentar excluir funcionario";
                }
                else
                    msgErro = "Falha ao tentar excluir funcionario";


                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {funcionarioId}", funcionario.Id);

                return Result.Fail(erros);
            }
            
        }

        protected override List<string> ValidarRegistro(Funcionario funcionario)
        {
            ValidationResult resultValidation = validadorFuncionario.Validate(funcionario);

            var erros = new List<string>();

            if (resultValidation != null)
                erros.AddRange(resultValidation.Errors.Select(e => e.ErrorMessage));

            if (NomeDuplicado(funcionario))
                erros.Add($"Esse nome: '{funcionario.Nome}' já está em uso!");

            foreach (string erro in erros)
                Log.Warning(erro);

            return erros;
        }

        protected override bool NomeDuplicado(Funcionario funcionario)
        {
            Funcionario funcionarioEncontrado = repositorioFuncionario.SelecionarPorNome(funcionario.Nome);

            if (funcionarioEncontrado != null &&
                funcionarioEncontrado.Id != funcionario.Id &&
                funcionarioEncontrado.Nome == funcionario.Nome)
            {
                return true;
            }
            else
                return false;
        }
    }
}
