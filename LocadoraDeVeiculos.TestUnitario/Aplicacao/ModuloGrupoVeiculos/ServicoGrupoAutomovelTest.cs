using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.TestUnitario.Compartilhado;
using Moq;

namespace LocadoraDeVeiculos.TestUnitario.Aplicacao.ModuloGrupoVeiculos
{
    [TestClass]
    public class ServicoGrupoAutomovelTest
    {
        Mock<IReposisotiroGrupoAutomovel> repositorioGrupoAutomovel;
        Mock<IValidadorGrupoAutomovel> validadorGrupo;
        Mock<IContextoPersistencia> contextoPersistencia;
        private GrupoAutomovel grupoAutomovel;

        private ServicoGrupoAutomovel servicoGrupoAutomovel;
        public ServicoGrupoAutomovelTest()
        {
            grupoAutomovel = new GrupoAutomovel("Suvs");

            repositorioGrupoAutomovel = new Mock<IReposisotiroGrupoAutomovel>();
            validadorGrupo = new Mock<IValidadorGrupoAutomovel>();
            contextoPersistencia = new Mock<IContextoPersistencia>();

            this.servicoGrupoAutomovel = new ServicoGrupoAutomovel(repositorioGrupoAutomovel.Object, validadorGrupo.Object, contextoPersistencia.Object);
        }

        [TestMethod]
        public void DeveInserirCasoInformacoesEstejamCorretas()
        {
            Result resultado = servicoGrupoAutomovel.Inserir(grupoAutomovel);

            resultado.Should().BeSuccess();
        }

        [TestMethod]
        public void NaoDeveInserirCasoInformacoesEstejamincorretas()
        {
            validadorGrupo.Setup(x => x.Validate(It.IsAny<GrupoAutomovel>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure());
                return resultado;
            });

            Result resultado = servicoGrupoAutomovel.Inserir(grupoAutomovel);

            resultado.Should().BeFailure();
        }

        [TestMethod]
        public void NaoDeveIsnerirCasoNomeJaEstejaSendoUsado()
        {
            repositorioGrupoAutomovel.Setup(x => x.SelecionarPorNome("Suvs")).Returns(() =>
            {
                return new GrupoAutomovel("Suvs");
            });

            Result resultado = servicoGrupoAutomovel.Inserir(grupoAutomovel);

            resultado.Should().BeFailure();
        }

        [TestMethod]
        public void DeveOcorrerTratamentoDeErroParaExessaoAoInserir()
        {
            repositorioGrupoAutomovel.Setup(x => x.Inserir(It.IsAny<GrupoAutomovel>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            Result resultado = servicoGrupoAutomovel.Inserir(grupoAutomovel);

            resultado.Should().BeFailure();
        }

        [TestMethod]
        public void DeveEditarGrupoCasoValido()
        {
            var resultado = servicoGrupoAutomovel.Editar(grupoAutomovel);

            resultado.Should().BeSuccess();
            repositorioGrupoAutomovel.Verify(x => x.Editar(grupoAutomovel), Times.Once);
        }

        [TestMethod]
        public void NaoDeveEditarGrupoCasoValido()
        {
            validadorGrupo.Setup(x => x.Validate(It.IsAny<GrupoAutomovel>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure());
                return resultado;
            });

            var resultado = servicoGrupoAutomovel.Editar(grupoAutomovel);

            resultado.Should().BeFailure();
            repositorioGrupoAutomovel.Verify(x => x.Editar(grupoAutomovel), Times.Never);
        }

        [TestMethod]
        public void DeveOcorrerTratamentoDeErroParaExcecaoAoEditar()
        {
            repositorioGrupoAutomovel.Setup(x => x.Editar(It.IsAny<GrupoAutomovel>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            Result resultado = servicoGrupoAutomovel.Editar(grupoAutomovel);

            resultado.Should().BeFailure();
        }


        [TestMethod]
        public void NaoDeveEditarCasoNomeJaEstejaSendoUsado()
        {
            repositorioGrupoAutomovel.Setup(x => x.SelecionarPorNome("Suvs")).Returns(() =>
            {
                return new GrupoAutomovel("Suvs");
            });

            Result resultado = servicoGrupoAutomovel.Editar(grupoAutomovel);

            resultado.Should().BeFailure();
        }

        [TestMethod]
        public void Deve_editar_funcionario_com_o_mesmo_nome()
        {
            Guid id = Guid.NewGuid();
            //arrange
            repositorioGrupoAutomovel.Setup(x => x.SelecionarPorNome("Suvs"))
                 .Returns(() =>
                 {
                     return new GrupoAutomovel("Suvs", id);
                 });

            var outroFuncionario = new GrupoAutomovel("Suvs", id);

            //action
            var resultado = servicoGrupoAutomovel.Editar(outroFuncionario);

            //assert 
            resultado.Should().BeSuccess();

            repositorioGrupoAutomovel.Verify(x => x.Editar(outroFuncionario), Times.Once());
        }

        [TestMethod]
        public void DeveTratarErroAoLancarExessao()
        {
            repositorioGrupoAutomovel.Setup(x => x.Editar(It.IsAny<GrupoAutomovel>()))
               .Throws(() =>
               {
                   return new Exception();
               });

            var resultado = servicoGrupoAutomovel.Editar(grupoAutomovel);

            resultado.Should().BeFailure();
        }

        [TestMethod]
        public void DeveSerPossivelExcluirGrupo()
        {
            repositorioGrupoAutomovel.Setup(x => x.Existe(It.IsAny<GrupoAutomovel>())).Returns(true);

            var resultado = servicoGrupoAutomovel.Excluir(grupoAutomovel);

            resultado.Should().BeSuccess();
        }

        [TestMethod]
        public void NaoDeveSerPossivelExcluirCasoNaoExistaGrupo()
        {
            repositorioGrupoAutomovel.Setup(x => x.Existe(It.IsAny<GrupoAutomovel>())).Returns(true);

            var resultado = servicoGrupoAutomovel.Excluir(grupoAutomovel);

            resultado.Should().BeSuccess();
        }


        [TestMethod]
        public void Nao_deve_excluir_funcionario_caso_ele_esteja_relacionada_com_materia()
        {
            repositorioGrupoAutomovel.Setup(x => x.Existe(grupoAutomovel))
               .Returns(() =>
               {
                   return true;
               });

            repositorioGrupoAutomovel.Setup(x => x.Excluir(It.IsAny<GrupoAutomovel>()))
                .Throws(() =>
                {
                    return SqlExceptionCreator.NewSqlException(errorMessage: "FK_TBGrupoAutomovel_TBVeiculo");
                });

            Result resultado = servicoGrupoAutomovel.Excluir(grupoAutomovel);

            resultado.Should().BeFailure();
        }

        [TestMethod]
        public void DeveTratarExessaoAoExcluirFuncionario()
        {
            repositorioGrupoAutomovel.Setup(x => x.Excluir(It.IsAny<GrupoAutomovel>()))
               .Throws(() =>
               {
                   return new Exception();
               });

            var resultado = servicoGrupoAutomovel.Excluir(grupoAutomovel);

            resultado.Should().BeFailure();
        }
    }
}
