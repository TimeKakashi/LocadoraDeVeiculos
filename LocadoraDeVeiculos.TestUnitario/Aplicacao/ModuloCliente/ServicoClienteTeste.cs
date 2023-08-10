using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.TestUnitario.Compartilhado;
using Moq;

namespace LocadoraDeVeiculos.TestUnitario.Aplicacao.ModuloCliente
{
    [TestClass]
    public class ServicoClienteTest
    {
        private Mock<IRepositorioCliente> repositorioClienteMock;
        private Mock<IValidadorCliente> validadorClienteMock;
        private Mock<IContextoPersistencia> ctxPersistencia;

        private ServicoCliente servicoCliente;
        private Cliente cliente;

        public ServicoClienteTest()
        {
            repositorioClienteMock = new Mock<IRepositorioCliente>();
            validadorClienteMock = new Mock<IValidadorCliente>();
            ctxPersistencia = new Mock<IContextoPersistencia>();

            servicoCliente = new ServicoCliente(repositorioClienteMock.Object, validadorClienteMock.Object, ctxPersistencia.Object);

            cliente = new Cliente(Cliente.TipoCliente.PessoaFisica, "João", "999999999", "email@teste.com", "Centro", "Cidade", "UF", "123", "Rua das Flores", "111.222.333-44");
        }

        [TestMethod]
        public void Deve_Inserir_Cliente_Com_Informacoes_Corretas()
        {
            validadorClienteMock.Setup(x => x.Validate(It.IsAny<Cliente>()))
                .Returns(new ValidationResult());

            repositorioClienteMock.Setup(x => x.SelecionarPorNome(It.IsAny<string>()))
                .Returns((string nome) => null);

            Result resultado = servicoCliente.Inserir(cliente);

            resultado.Should().BeSuccess();
            repositorioClienteMock.Verify(x => x.Inserir(cliente), Times.Once);
        }

        [TestMethod]
        public void Nao_Deve_Inserir_Cliente_Com_Informacoes_Invalidas()
        {
            var clienteInvalido = new Cliente(Cliente.TipoCliente.PessoaFisica, "João", "999999999", "email@teste.com", "Centro", "Cidade", "UF", "123", "Rua das Flores", "111.222.333-44");

            validadorClienteMock.Setup(x => x.Validate(It.IsAny<Cliente>()))
                .Returns(new ValidationResult(new List<ValidationFailure>
                {
                new ValidationFailure("Nome", "Número de caracteres insuficientes!")
                }));

            Result resultado = servicoCliente.Inserir(clienteInvalido);

            resultado.Should().BeFailure();
            repositorioClienteMock.Verify(x => x.Inserir(clienteInvalido), Times.Never);
        }

        [TestMethod]
        public void Nao_Deve_Inserir_Cliente_Caso_O_Nome_Ja_Esteja_Cadastrado()
        {
            string nomeCliente = "João";
            repositorioClienteMock.Setup(x => x.SelecionarPorNome(nomeCliente))
                .Returns(new Cliente(Cliente.TipoCliente.PessoaFisica, "João", "888888888", "email@teste.com", "Centro", "Cidade", "UF", "123", "Rua das Flores", "555.666.777-88"));

            validadorClienteMock.Setup(x => x.Validate(It.IsAny<Cliente>()))
                .Returns(new ValidationResult());

            Result resultado = servicoCliente.Inserir(cliente);

            resultado.Should().BeFailure();
            repositorioClienteMock.Verify(x => x.Inserir(cliente), Times.Never());
        }

        [TestMethod]
        public void Deve_Editar_Cliente_Com_Informacoes_Corretas()
        {
            repositorioClienteMock.Setup(x => x.SelecionarPorId(It.IsAny<Guid>()))
                .Returns(cliente);

            validadorClienteMock.Setup(x => x.Validate(It.IsAny<Cliente>()))
                .Returns(new ValidationResult());

            Result resultado = servicoCliente.Editar(cliente);

            resultado.Should().BeSuccess();
            repositorioClienteMock.Verify(x => x.Editar(cliente), Times.Once);
        }

        [TestMethod]
        public void Nao_Deve_Editar_Cliente_Com_Informacoes_Invalidas()
        {
            var clienteInvalido = new Cliente(Cliente.TipoCliente.PessoaFisica, "João", "999999999", "email@teste.com", "Centro", "Cidade", "UF", "123", "Rua das Flores", "111.222.333-44");

            validadorClienteMock.Setup(x => x.Validate(It.IsAny<Cliente>()))
                .Returns(new ValidationResult(new List<ValidationFailure>
                {
                new ValidationFailure("Nome", "Número de caracteres insuficientes!")
                }));

            Result resultado = servicoCliente.Editar(clienteInvalido);

            resultado.Should().BeFailure();
            repositorioClienteMock.Verify(x => x.Editar(clienteInvalido), Times.Never);
        }

        [TestMethod]
        public void Nao_Deve_Editar_Cliente_Caso_O_Nome_Ja_Esteja_Cadastrado()
        {
            string nomeCliente = "João";
            repositorioClienteMock.Setup(x => x.SelecionarPorNome(nomeCliente))
                .Returns(new Cliente(Cliente.TipoCliente.PessoaFisica, "João", "888888888", "email@teste.com", "Centro", "Cidade", "UF", "123", "Rua das Flores", "555.666.777-88"));

            validadorClienteMock.Setup(x => x.Validate(It.IsAny<Cliente>()))
                .Returns(new ValidationResult());

            Result resultado = servicoCliente.Editar(cliente);

            resultado.Should().BeFailure();
            repositorioClienteMock.Verify(x => x.Editar(cliente), Times.Never());
        }

        [TestMethod]
        public void Deve_Excluir_Cliente_Caso_Ele_Esteja_Cadastrado()
        {
            repositorioClienteMock.Setup(x => x.Existe(cliente))
                .Returns(true);

            Result resultado = servicoCliente.Excluir(cliente);

            resultado.Should().BeSuccess();
            repositorioClienteMock.Verify(x => x.Excluir(cliente), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_Excluir_Cliente_Caso_Ele_Nao_Esteja_Cadastrado()
        {
            repositorioClienteMock.Setup(x => x.Existe(cliente))
                .Returns(false);

            Result resultado = servicoCliente.Excluir(cliente);

            resultado.Should().BeFailure();
            repositorioClienteMock.Verify(x => x.Excluir(cliente), Times.Never());
        }

        [TestMethod]
        public void Nao_Deve_Excluir_Cliente_Caso_Ele_Esteja_Relacionado_Com_Aluguel()
        {
            repositorioClienteMock.Setup(x => x.Existe(cliente))
                .Returns(true);

            repositorioClienteMock.Setup(x => x.Excluir(It.IsAny<Cliente>()))
                .Throws(() =>
                {
                    return SqlExceptionCreator.NewSqlException(errorMessage: "FK_TBCliente_TBAluguel");
                });

            Result resultado = servicoCliente.Excluir(cliente);

            resultado.Should().BeFailure();
        }

        [TestMethod]
        public void Deve_Tentar_Excluir_Cliente_E_Capturar_Erro_Caso_Ocorra_Falha_No_Banco()
        {
            repositorioClienteMock.Setup(x => x.Existe(cliente))
                .Throws(() =>
                {
                    return SqlExceptionCreator.NewSqlException();
                });

            Result resultado = servicoCliente.Excluir(cliente);

            resultado.Should().BeFailure();
        }
        [TestMethod]
        public void Deve_Inserir_Cliente_PessoaJuridica_Com_Informacoes_Corretas()
        {
            var clientePessoaJuridica = new Cliente(Cliente.TipoCliente.PessoaJuridica, "Empresa XYZ", "88888888", "empresa@teste.com", "Centro", "Cidade", "UF", "123", "Rua Comercial", "12.345.678/0001-90");

            validadorClienteMock.Setup(x => x.Validate(It.IsAny<Cliente>()))
                .Returns(new ValidationResult());

            repositorioClienteMock.Setup(x => x.SelecionarPorNome(It.IsAny<string>()))
                .Returns((string nome) => null);

            Result resultado = servicoCliente.Inserir(clientePessoaJuridica);

            resultado.Should().BeSuccess();
            repositorioClienteMock.Verify(x => x.Inserir(clientePessoaJuridica), Times.Once);
        }

        [TestMethod]
        public void Nao_Deve_Inserir_Cliente_PessoaJuridica_Com_Informacoes_Invalidas()
        {
            var clienteInvalido = new Cliente(Cliente.TipoCliente.PessoaJuridica, "Empresa XYZ", "88888888", "empresa@teste.com", "Centro", "Cidade", "UF", "123", "Rua Comercial", "12.345.678/0001-90");

            validadorClienteMock.Setup(x => x.Validate(It.IsAny<Cliente>()))
                .Returns(new ValidationResult(new List<ValidationFailure>
                {
            new ValidationFailure("CNPJ", "CNPJ inválido")
                }));

            Result resultado = servicoCliente.Inserir(clienteInvalido);

            resultado.Should().BeFailure();
            repositorioClienteMock.Verify(x => x.Inserir(clienteInvalido), Times.Never);
        }

        [TestMethod]
        public void Deve_Editar_Cliente_Com_Informacoes_Corretas_PessoaJuridica()
        {
            var clientePessoaJuridica = new Cliente(Cliente.TipoCliente.PessoaJuridica, "Empresa XYZ", "88888888", "empresa@teste.com", "Centro", "Cidade", "UF", "123", "Rua Comercial", "12.345.678/0001-90");

            repositorioClienteMock.Setup(x => x.SelecionarPorId(It.IsAny<Guid>()))
                .Returns(clientePessoaJuridica);

            validadorClienteMock.Setup(x => x.Validate(It.IsAny<Cliente>()))
                .Returns(new ValidationResult());

            Result resultado = servicoCliente.Editar(clientePessoaJuridica);

            resultado.Should().BeSuccess();
            repositorioClienteMock.Verify(x => x.Editar(clientePessoaJuridica), Times.Once);
        }

        [TestMethod]
        public void Nao_Deve_Editar_Cliente_Com_Informacoes_Invalidas_PessoaJuridica()
        {
            var clienteInvalido = new Cliente(Cliente.TipoCliente.PessoaJuridica, "Empresa XYZ", "88888888", "empresa@teste.com", "Centro", "Cidade", "UF", "123", "Rua Comercial", "12.345.678/0001-90");

            validadorClienteMock.Setup(x => x.Validate(It.IsAny<Cliente>()))
                .Returns(new ValidationResult(new List<ValidationFailure>
                {
            new ValidationFailure("CNPJ", "CNPJ inválido")
                }));

            Result resultado = servicoCliente.Editar(clienteInvalido);

            resultado.Should().BeFailure();
            repositorioClienteMock.Verify(x => x.Editar(clienteInvalido), Times.Never);
        }

        [TestMethod]
        public void Deve_Excluir_Cliente_Com_Informacoes_Corretas()
        {
            repositorioClienteMock.Setup(x => x.Existe(cliente))
                .Returns(true);

            Result resultado = servicoCliente.Excluir(cliente);

            resultado.Should().BeSuccess();
            repositorioClienteMock.Verify(x => x.Excluir(cliente), Times.Once());
        }

        [TestMethod]
        public void Deve_Excluir_Cliente_Com_Informacoes_Corretas_PessoaJuridica()
        {
            var clientePessoaJuridica = new Cliente(Cliente.TipoCliente.PessoaJuridica, "Empresa XYZ", "88888888", "empresa@teste.com", "Centro", "Cidade", "UF", "123", "Rua Comercial", "12.345.678/0001-90");

            repositorioClienteMock.Setup(x => x.Existe(clientePessoaJuridica))
                .Returns(true);

            Result resultado = servicoCliente.Excluir(clientePessoaJuridica);

            resultado.Should().BeSuccess();
            repositorioClienteMock.Verify(x => x.Excluir(clientePessoaJuridica), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_Excluir_Cliente_Caso_Ele_Nao_Esteja_Relacionado_Com_Aluguel()
        {
            repositorioClienteMock.Setup(x => x.Existe(cliente))
                .Returns(true);

            repositorioClienteMock.Setup(x => x.Excluir(It.IsAny<Cliente>()))
                .Throws(() =>
                {
                    return SqlExceptionCreator.NewSqlException(errorMessage: "FK_TBCliente_TBAluguel");
                });

            Result resultado = servicoCliente.Excluir(cliente);

            resultado.Should().BeFailure();
        }

        [TestMethod]
        public void Nao_Deve_Excluir_Cliente_Caso_Ele_Nao_Esteja_Relacionado_Com_Aluguel_PessoaJuridica()
        {
            var clientePessoaJuridica = new Cliente(Cliente.TipoCliente.PessoaJuridica, "Empresa XYZ", "88888888", "empresa@teste.com", "Centro", "Cidade", "UF", "123", "Rua Comercial", "12.345.678/0001-90");

            repositorioClienteMock.Setup(x => x.Existe(clientePessoaJuridica))
                .Returns(true);

            repositorioClienteMock.Setup(x => x.Excluir(It.IsAny<Cliente>()))
                .Throws(() =>
                {
                    return SqlExceptionCreator.NewSqlException(errorMessage: "FK_TBCliente_TBAluguel");
                });

            Result resultado = servicoCliente.Excluir(clientePessoaJuridica);

            resultado.Should().BeFailure();
        }

        [TestMethod]
        public void Deve_Tentar_Excluir_Cliente_E_Capturar_Erro_Caso_Ocorra_Falha_No_Banco_PessoaJuridica()
        {
            var clientePessoaJuridica = new Cliente(Cliente.TipoCliente.PessoaJuridica, "Empresa XYZ", "88888888", "empresa@teste.com", "Centro", "Cidade", "UF", "123", "Rua Comercial", "12.345.678/0001-90");

            repositorioClienteMock.Setup(x => x.Existe(clientePessoaJuridica))
                .Throws(() =>
                {
                    return SqlExceptionCreator.NewSqlException();
                });

            Result resultado = servicoCliente.Excluir(clientePessoaJuridica);

            resultado.Should().BeFailure();
        }

    }


}
