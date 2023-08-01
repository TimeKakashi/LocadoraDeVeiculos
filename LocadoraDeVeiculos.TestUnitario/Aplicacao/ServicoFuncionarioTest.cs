using FluentAssertions;
using FluentResults;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using Moq;
using FluentResults.Extensions.FluentAssertions;
using System.Net.Http.Headers;
using FluentValidation.Results;
using LocadoraDeVeiculos.TestUnitario.Compartilhado;

namespace LocadoraDeVeiculos.TestUnitario.Aplicacao
{
    [TestClass]

    public class ServicoFuncionarioTest
    {
        Mock<IRepositorioFuncionario> repositorioFuncionarioMock;
        Mock<IValidadorFuncionario> validadorMock;

        private ServicoFuncionario servicoFuncionario;
        private Funcionario funcionario;

        public ServicoFuncionarioTest()
        {
            repositorioFuncionarioMock = new Mock<IRepositorioFuncionario>();
            validadorMock = new Mock<IValidadorFuncionario>();

            servicoFuncionario = new ServicoFuncionario(repositorioFuncionarioMock.Object, validadorMock.Object);

            funcionario = new Funcionario("Pedro", 1200, DateTime.Today);
        }

        [TestMethod]

        public void Deve_Inserir_Funcionario_Com_Informacoes_Corretas()
        {
            Result resultado = servicoFuncionario.Inserir(funcionario);

            resultado.Should().BeSuccess();
            repositorioFuncionarioMock.Verify(x => x.Inserir(funcionario), Times.Once);
        }

        [TestMethod]
        public void Nao_Deve_Inserir_Funcionario_Com_Informacoes_Invalidas()
        {
            var funcionario2 = new Funcionario("a", 100, DateTime.Today);

            validadorMock.Setup(x => x.Validate(It.IsAny<Funcionario>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("Nome", "Numero de caracteres insuficientes!"));
                return resultado;
            });

            Result resultado = servicoFuncionario.Inserir(funcionario2);

            resultado.Should().BeFailure();
            repositorioFuncionarioMock.Verify(x => x.Inserir(funcionario2), Times.Never);
        }

        [TestMethod]
        public void Nao_deve_inserir_Funcionario_caso_o_nome_ja_esteja_cadastrado() //cenário 3
        {
            //arrange
            string nomeFuncionario = "Pedro";
            repositorioFuncionarioMock.Setup(x => x.SelecionarPorNome(nomeFuncionario))
                .Returns(() =>
                {
                    return new Funcionario(nomeFuncionario, 2000, DateTime.Today);
                });

            //action
            var resultado = servicoFuncionario.Inserir(funcionario);

            //assert 
            resultado.Should().BeFailure();
            repositorioFuncionarioMock.Verify(x => x.Inserir(funcionario), Times.Never());
        }

        [TestMethod]
        public void Deve_Ocorrer_Tratamento_Erro_Ao_Tentar_Inserir_Funcionario()
        {
            repositorioFuncionarioMock.Setup(x => x.Inserir(It.IsAny<Funcionario>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            Result resultado = servicoFuncionario.Inserir(funcionario);

            resultado.Should().BeFailure();
        }

        [TestMethod]
        public void Deve_editar_funcionario_caso_ele_for_valido() 
        {
            var funcionario1 = new Funcionario("jose", 1500, DateTime.Today);

            Result resultado = servicoFuncionario.Editar(funcionario1);

            resultado.Should().BeSuccess();
            repositorioFuncionarioMock.Verify(x => x.Editar(funcionario1), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_funcionario_caso_ele_seja_invalido() 
        {
            //arrange
            validadorMock.Setup(x => x.Validate(It.IsAny<Funcionario>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoFuncionario.Editar(funcionario);

            //assert             
            resultado.Should().BeFailure();
            repositorioFuncionarioMock.Verify(x => x.Editar(funcionario), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_editar_funcionario_caso_o_nome_ja_esteja_cadastrado() 
        {
            //arrange
            repositorioFuncionarioMock.Setup(x => x.SelecionarPorNome("koe"))
                 .Returns(() =>
                 {
                     return new Funcionario("koe", 100, DateTime.Today);
                 });

            Funcionario novoFuncionario = new Funcionario("koe", 100, DateTime.Today);

            //action
            var resultado = servicoFuncionario.Editar(novoFuncionario);

            //assert 
            resultado.Should().BeFailure();

            repositorioFuncionarioMock.Verify(x => x.Editar(novoFuncionario), Times.Never());
        }

        [TestMethod]
        public void Deve_editar_funcionario_com_o_mesmo_nome()
        {
            //arrange
            repositorioFuncionarioMock.Setup(x => x.SelecionarPorNome("jae"))
                 .Returns(() =>
                 {
                     return new Funcionario("jae", 100, DateTime.Today);
                 });

            var outroFuncionario = new Funcionario("jae", 100, DateTime.Today);

            //action
            var resultado = servicoFuncionario.Editar(outroFuncionario);

            //assert 
            resultado.Should().BeSuccess();

            repositorioFuncionarioMock.Verify(x => x.Editar(outroFuncionario), Times.Once());
        }

        [TestMethod]

        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_funcionario() 
        {
            repositorioFuncionarioMock.Setup(x => x.Editar(It.IsAny<Funcionario>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            Result resultado = servicoFuncionario.Editar(funcionario);

            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar funcionario.");
        }

        [TestMethod]
        public void Deve_excluir_funcionario_caso_ele_esteja_cadastrada() //cenário 1
        {
            //arrange
            var disciplina = new Funcionario("pedro", 100, DateTime.Today);

            repositorioFuncionarioMock.Setup(x => x.Existe(disciplina))
               .Returns(() =>
               {
                   return true;
               });

            var resultado = servicoFuncionario.Excluir(disciplina);

            //assert 
            resultado.Should().BeSuccess();
            repositorioFuncionarioMock.Verify(x => x.Excluir(disciplina), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_funcionario_caso_ele_nao_esteja_cadastrada() //cenário 2
        {
            var disciplina = new Funcionario("pedro", 100, DateTime.Today);

            repositorioFuncionarioMock.Setup(x => x.Existe(disciplina))
               .Returns(() =>
               {
                   return false;
               });

            var resultado = servicoFuncionario.Excluir(disciplina);

            resultado.Should().BeFailure();
            repositorioFuncionarioMock.Verify(x => x.Excluir(disciplina), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_excluir_funcionario_caso_ele_esteja_relacionada_com_materia() //cenário 3
        {
            var disciplina = new Funcionario("pedro", 100, DateTime.Today);

            repositorioFuncionarioMock.Setup(x => x.Existe(disciplina))
               .Returns(() =>
               {
                   return true;
               });

            repositorioFuncionarioMock.Setup(x => x.Excluir(It.IsAny<Funcionario>()))
                .Throws(() =>
                {
                    return SqlExceptionCreator.NewSqlException(errorMessage: "FK_TBFuncionario_TBAluguel");
                });

            Result resultado = servicoFuncionario.Excluir(disciplina);

            resultado.Should().BeFailure();
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_funcionario()
        {
            var disciplina = new Funcionario("pedro", 100, DateTime.Today);

            repositorioFuncionarioMock.Setup(x => x.Existe(disciplina))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = servicoFuncionario.Excluir(disciplina);

            //assert 
            resultado.Should().BeFailure();
        }
    }
}
