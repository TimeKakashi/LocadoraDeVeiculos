using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraDeVeiculos.Aplicacao.ModuloAluguel;
using LocadoraDeVeiculos.Aplicacao.ModuloAutomovel;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.TestUnitario.Compartilhado;
using Moq;


namespace LocadoraDeVeiculos.TestUnitario.Aplicacao.ModuloAluguel
{
    [TestClass]
    public class ServicoAluguelTest
    {
        private Mock<IValidadorAluguel> validadorAluguel;
        private Mock<IContextoPersistencia> contextoPersistencia;
        private Mock<IRepositorioAluguel> repositorioAluguel;
        private Mock<IRepositorioCupom> repositorioCupom;
        private Mock<IRepositorioCombustivelJson> repositorioCombustivel;

        private ServicoAluguel servicoAluguel;
        private Aluguel aluguel;

        public ServicoAluguelTest()
        {
            validadorAluguel = new Mock<IValidadorAluguel>();
            contextoPersistencia = new Mock<IContextoPersistencia>();
            repositorioAluguel = new Mock<IRepositorioAluguel>();
            repositorioCupom = new Mock<IRepositorioCupom>();
            repositorioCombustivel = new Mock<IRepositorioCombustivelJson>();

            servicoAluguel = new ServicoAluguel(repositorioAluguel.Object, repositorioCupom.Object, repositorioCombustivel.Object, validadorAluguel.Object, contextoPersistencia.Object);

            var funcionario = new Funcionario("NomeFuncionario", 2000, DateTime.Now);
            var cliente = new Cliente(Cliente.TipoCliente.PessoaFisica, "NomeCliente", "12345678901", "EmailCliente@gmail.com", "Bairro Cliente", "Cidade Cliente", "CE", "1", "TelefoneCliente", "12345678901");
            var grupoAutomovel = new GrupoAutomovel("Grupo A");
            var planoC = new PlanoCobranca(planoCobranca.Diaria, 10, 10);
            var veiculo = new Veiculo("Modelo X", "Marca Y", "Azul", new byte[100], 10000, "ABC1234", EnumCombusteivel.Gasolina, 50, grupoAutomovel, false);
            var condutor = new Condutor("asdasd", "12312312323", "1231231232", DateTime.Now.AddDays(5), "12312312323", "teste@gmail.com");

            aluguel = new Aluguel(funcionario, cliente, grupoAutomovel, planoC, veiculo, null, DateTime.Now, DateTime.Now.AddDays(7), 400, false, condutor);
        }

        [TestMethod]
        public void DeveInserirAluguelValido()
        {
            validadorAluguel.Setup(x => x.Validate(aluguel)).Returns(new ValidationResult());

            Result resultado = servicoAluguel.Inserir(aluguel);

            resultado.IsSuccess.Should().BeTrue();
        }

        [TestMethod]
        public void NaoDeveInserirAluguelInValido()
        {
            validadorAluguel.Setup(x => x.Validate(aluguel)).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("Nome", "Deve ter 3 letras no minimo!"));
                return resultado;
            });

            Result resultado = servicoAluguel.Inserir(aluguel);

            resultado.IsSuccess.Should().BeFalse();
        }

        [TestMethod]
        public void DeveOcorrerTratamentoDeExessaoAoTentarinserirAluguel()
        {
            repositorioAluguel.Setup(x => x.Inserir(aluguel)).Throws(() =>
            {
                return new Exception();
            });

            Result resultado = servicoAluguel.Inserir(aluguel);

            resultado.IsSuccess.Should().BeFalse();
        }

        [TestMethod]
        public void DeveEditarCasoValido()
        {
            Result resultado = servicoAluguel.Editar(aluguel);

            resultado.Should().BeSuccess();
            repositorioAluguel.Verify(x => x.Editar(aluguel), Times.Once());
        }

        [TestMethod]
        public void NaoDeveEditarCasoSejaInvalido()
        {
            validadorAluguel.Setup(x => x.Validate(It.IsAny<Aluguel>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();

                    resultado.Errors.Add(new ValidationFailure("Km", "Deve Selecionar a quantiade de km"));

                    return resultado;
                });

            var resultado = servicoAluguel.Editar(aluguel);

            resultado.Should().BeFailure();
        }

        [TestMethod]
        public void DeveOcorrerTratamentoDeExessaoAoEditar()
        {

            repositorioAluguel.Setup(x => x.Editar(aluguel))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            Result resultado = servicoAluguel.Editar(aluguel);

            resultado.Should().BeFailure();
        }

        [TestMethod]
        public void DeveExcluirAluguelCasoExista()
        {
            repositorioAluguel.Setup(x => x.Existe(aluguel)).Returns(true);

            Result resultado = servicoAluguel.Excluir(aluguel);

            resultado.Should().BeSuccess();
        }

        [TestMethod]
        public void NaoDeveExcluirAluguelCasoEleNaoExista()
        {
            repositorioAluguel.Setup(x => x.Existe(aluguel)).Returns(false);

            Result resultado = servicoAluguel.Excluir(aluguel);

            resultado.Should().BeFailure();
        }


        [TestMethod]
        public void DeveOcorrerTratamentoDeExessaoAoFalharEmExcluirAlugel()
        {

            repositorioAluguel.Setup(x => x.Excluir(aluguel))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            Result resultado = servicoAluguel.Excluir(aluguel);

            resultado.Should().BeFailure();
        }

        [TestMethod]
        public void NaoDeveSerPossivelEditarAluguelFinalizado()
        {
            repositorioAluguel.Setup(x => x.Existe(aluguel)).Returns(true);

            aluguel.Finalizado = true;

            Result resultado = servicoAluguel.Excluir(aluguel);

            resultado.Should().BeFailure();
        }

    }
}
