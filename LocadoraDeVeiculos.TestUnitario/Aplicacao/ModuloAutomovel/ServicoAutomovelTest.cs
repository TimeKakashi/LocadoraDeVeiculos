using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraDeVeiculos.Aplicacao.ModuloAutomovel;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.TestUnitario.Compartilhado;
using Moq;

namespace LocadoraDeVeiculos.TestUnitario.Aplicacao.ModuloAutomovel
{
    [TestClass]
    public class ServicoAutomovelTest
    {
        private Mock<IRepositorioAutomovel> repositorioAutomovelMock;
        private Mock<IValidadorAutomovel> validadorAutomovelMock;
        private Mock<IContextoPersistencia> ctx;
        private ServicoAutomovel servicoAutomovel;
        private Veiculo veiculo;
        private GrupoAutomovel grupoAutomovel;

        public ServicoAutomovelTest()
        {
            repositorioAutomovelMock = new Mock<IRepositorioAutomovel>();
            validadorAutomovelMock = new Mock<IValidadorAutomovel>();
            ctx = new Mock<IContextoPersistencia>();


            servicoAutomovel = new ServicoAutomovel(repositorioAutomovelMock.Object, validadorAutomovelMock.Object, ctx.Object);

            grupoAutomovel = new GrupoAutomovel("Esportivo");
            veiculo = new Veiculo("Spider", "Ferrari", "preto", new byte[100], 100, "MIY4565", EnumCombusteivel.Gasolina, 40, grupoAutomovel, false);
        }

        [TestMethod]
        public void DeveInserirVeiculoComDadosCorretos()
        {
            validadorAutomovelMock.Setup(x => x.Validate(It.IsAny<Veiculo>())).Returns(new ValidationResult());

            Result resultado = servicoAutomovel.Inserir(veiculo);

            resultado.Should().BeSuccess();
        }

        [TestMethod]
        public void NaoDeveInserirVeiculoComDadosIncorretos()
        {
            validadorAutomovelMock.Setup(x => x.Validate(It.IsAny<Veiculo>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("Nome", "Numero de caracteres insuficientes!"));
                return resultado;
            });

            Result resultado = servicoAutomovel.Inserir(veiculo);

            resultado.Should().BeFailure();
        }

        [TestMethod]
        public void DeveOcorrerTratamentoDeErroAoTentarInserirVeiculo()
        {
            repositorioAutomovelMock.Setup(x => x.Inserir(It.IsAny<Veiculo>()))
               .Throws(() =>
               {
                   return new Exception();
               });

            Result resultado = servicoAutomovel.Inserir(veiculo);

            resultado.Should().BeFailure();
        }

        [TestMethod]
        public void DeveEditarVeiculoCasoEleFoValido()
        {
            Result resultado = servicoAutomovel.Editar(veiculo);

            resultado.Should().BeSuccess();
            repositorioAutomovelMock.Verify(x => x.Editar(veiculo), Times.Once());
        }

        [TestMethod]
        public void NaoDeveEditarCasoSejaInvalido()
        {
            validadorAutomovelMock.Setup(x => x.Validate(It.IsAny<Veiculo>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Km", "Quantidade de km invalida"));
                    return resultado;
                });

            var resultado = servicoAutomovel.Editar(veiculo);

            resultado.Should().BeFailure();
        }

        [TestMethod]
        public void DeveOcorrerTratamentoDeExessaoAoEditar()
        {

            repositorioAutomovelMock.Setup(x => x.Editar(veiculo))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            Result resultado = servicoAutomovel.Editar(veiculo);

            resultado.Should().BeFailure();
        }

        [TestMethod]
        public void DeveExcluirVeiculoCasoEleExista()
        {
            repositorioAutomovelMock.Setup(x => x.Existe(veiculo)).Returns(true);

            Result resultado = servicoAutomovel.Excluir(veiculo);

            resultado.Should().BeSuccess();
        }

        [TestMethod]
        public void NaoDeveExcluirVeiculoCasoEleNaoExista()
        {
            repositorioAutomovelMock.Setup(x => x.Existe(veiculo)).Returns(false);

            Result resultado = servicoAutomovel.Excluir(veiculo);

            resultado.Should().BeFailure();
        }

        [TestMethod]
        public void DeveOcorrerTratamentoDeExessaoAoExcluirVeiculo()
        {

            repositorioAutomovelMock.Setup(x => x.Excluir(veiculo))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            Result resultado = servicoAutomovel.Excluir(veiculo);

            resultado.Should().BeFailure();
        }

        [TestMethod]
        public void NaoDeveSerPossivelExcluirVeiculoRelacionadoAlugel()
        {
            repositorioAutomovelMock.Setup(x => x.Existe(veiculo)).Returns(true);

            repositorioAutomovelMock.Setup(x => x.Excluir(veiculo))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException(errorMessage: "FK_TBFuncionario_TBAluguel");
              });

            var resultado = servicoAutomovel.Excluir(veiculo);

            resultado.Should().BeFailure(); 
        }
    }
}
