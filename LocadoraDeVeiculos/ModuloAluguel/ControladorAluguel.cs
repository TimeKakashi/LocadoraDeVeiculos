using FluentResults;
using iTextSharp.text.pdf;
using LocadoraDeVeiculos.Aplicacao.ModuloAluguel;
using LocadoraDeVeiculos.Aplicacao.ModuloAutomovel;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

namespace LocadoraDeVeiculos.ModuloAluguel
{
    public class ControladorAluguel : ControladorBase
    {
        public override string ToolTipInserir => "Inserir Alguel";
        public override string ToolTipEditar => "Editar Alguel";
        public override string ToolTipExcluir => "Excluir Alguel";
        public override string ToolTipFiltrar => "Filtrar Alguel";
        public override string ToolTipPdf => "Gerar e Encaminhar Pdf por Email";
        public override string ToolTipCombustivel => "Atualizar Valores Combustível";
        public override bool DevolucaoHabilitado => true;

        private TabelaAluguel tabelaAluguel;
        private ServicoAluguel servicoAluguel;
        private IRepositorioAluguel repositorioAluguel;
        private IRepositorioFuncionario repositorioFuncionario;
        private IRepositorioCliente repositorioCliente;
        private IReposisotiroGrupoAutomovel reposisotiroGrupoAutomovel;
        private IRepositorioCupom repositorioCupom;
        private IRepositorioTaxaServico repositorioTaxaServico;
        private IRepositorioCondutor repositorioCondutor;
        private IRepositorioAutomovel repositorioAutomovel;
        private IRepositorioPlanoCobranca repositorioPlanoCobranca;

        public ControladorAluguel(ServicoAluguel servicoAluguel, IRepositorioAluguel repositorioAluguel)
        {
            this.servicoAluguel = servicoAluguel;
            this.repositorioAluguel = repositorioAluguel;
        }

        public ControladorAluguel(ServicoAluguel servicoAluguel, IRepositorioAluguel repositorioAluguel,
            IRepositorioFuncionario repositorioFuncionario, IRepositorioCliente repositorioCliente,
            IReposisotiroGrupoAutomovel reposisotiroGrupoAutomovel,IRepositorioCupom repositorioCupom,
            IRepositorioTaxaServico repositorioTaxaServico
)
            : this(servicoAluguel, repositorioAluguel)
        {
            this.repositorioFuncionario = repositorioFuncionario;
            this.repositorioCliente = repositorioCliente;
            this.reposisotiroGrupoAutomovel = reposisotiroGrupoAutomovel;
            this.repositorioCupom = repositorioCupom;
            this.repositorioTaxaServico = repositorioTaxaServico;
        }
        public ControladorAluguel(ServicoAluguel servicoAluguel, IRepositorioAluguel repositorioAluguel, IRepositorioFuncionario repositorioFuncionario,
         IRepositorioCliente repositorioCliente, IReposisotiroGrupoAutomovel reposisotiroGrupoAutomovel, IRepositorioCupom repositorioCupom,
         IRepositorioTaxaServico repositorioTaxaServico, IRepositorioCondutor repositorioCondutor, IRepositorioAutomovel repositorioAutomovel,
         IRepositorioPlanoCobranca repositorioPlanoCobranca) : this(servicoAluguel, repositorioAluguel, repositorioFuncionario, repositorioCliente,
             reposisotiroGrupoAutomovel, repositorioCupom, repositorioTaxaServico)
        {
            this.repositorioCondutor = repositorioCondutor;
            this.repositorioAutomovel = repositorioAutomovel;
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
        }

        public override void CarregarItens()
        {
            var listaAutomovel = repositorioAluguel.SelecionarTodos();

            tabelaAluguel.AtualizarRegistros(listaAutomovel);
        }

        public override void Inserir()
        {
            TelaAluguelForm talaAluguel = new TelaAluguelForm(
                repositorioFuncionario.SelecionarTodos(),
                repositorioCliente.SelecionarTodos(true),
                reposisotiroGrupoAutomovel.SelecionarTodos(true, true),
                repositorioTaxaServico.SelecionarTodos(), repositorioCupom.SelecionarTodos()
                );

            talaAluguel.onGravarRegistro += servicoAluguel.Inserir;

            talaAluguel.onProcurarCupom += servicoAluguel.ProcurarCupom;

            talaAluguel.ArrumaTela(new Aluguel(), true);

            if (talaAluguel.ShowDialog() == DialogResult.OK)
                CarregarItens();
        }

        public override void Editar()
        {
            Aluguel aluguel = ObterAluguelSelecionado();

            if (aluguel == null)
            {
                MessageBox.Show("Selecione um alguel primeiro!", "Edição de alguel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (aluguel.Finalizado)
            {
                MessageBox.Show("Este aluguel já foi finalizado, nao é possivel Editalo");
                return;
            }

            TelaAluguelForm talaAluguel = new TelaAluguelForm(
               repositorioFuncionario.SelecionarTodos(),
               repositorioCliente.SelecionarTodos(true),
               reposisotiroGrupoAutomovel.SelecionarTodos(true, true),
               repositorioTaxaServico.SelecionarTodos(), repositorioCupom.SelecionarTodos()
               );

            talaAluguel.ArrumaTela(aluguel, false);

            talaAluguel.onGravarRegistro += servicoAluguel.Editar;

            talaAluguel.onProcurarCupom += servicoAluguel.ProcurarCupom;

            if (talaAluguel.ShowDialog() == DialogResult.OK)
                CarregarItens();
        }

        private Aluguel ObterAluguelSelecionado()
        {
            var id = tabelaAluguel.ObterIdSelecionado();

            return repositorioAluguel.SelecionarPorId(id);
        }

        public override void Excluir()
        {
            var aluguel = ObterAluguelSelecionado();

            if (aluguel == null)
            {
                MessageBox.Show("Selecione um veiculo primeiro!",
                    "Exclusão de veiculo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            if (aluguel.Finalizado)
            {
                MessageBox.Show("Este aluguel já foi finalizado, nao é possivel Excluir-lo");
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir o aluguel do cliente: {aluguel.Cliente} com o veiculo: {aluguel.Veiculo.Modelo}?", "Exclusão de aluguel",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result result = servicoAluguel.Excluir(aluguel);

                if (result.IsFailed)
                {
                    MessageBox.Show(result.Errors[0].Message, "Exclusão de aluguel", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }

            CarregarItens();
        }

        public override UserControl ObterTabela()
        {
            if (tabelaAluguel == null)
                tabelaAluguel = new TabelaAluguel();

            CarregarItens();

            return tabelaAluguel;
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Alugueis";
        }

        public override void DevolucaoAluguel()
        {
            var aluguel = ObterAluguelSelecionado();

            if (aluguel.Finalizado)
            {
                MessageBox.Show("Este aluguel já foi finalizado, nao é possivel finalizar novamente");
                return;
            }

            TelaDevolucaoForm telaDevolucao = new TelaDevolucaoForm(repositorioFuncionario.SelecionarTodos(),
                repositorioCliente.SelecionarTodos(true),
                reposisotiroGrupoAutomovel.SelecionarTodos(true, true),
                repositorioTaxaServico.SelecionarTodos(), repositorioCupom.SelecionarTodos(),
                repositorioCondutor.SelecionarTodos(), reposisotiroGrupoAutomovel.SelecionarTodos(),
                repositorioPlanoCobranca.SelecionarTodos(), repositorioAutomovel.SelecionarTodos());

            telaDevolucao.onPegarValorCombustivelNome += servicoAluguel.PegarValorGasolina;

            telaDevolucao.onProcurarCupomNome += servicoAluguel.ProcurarCupom;

            telaDevolucao.onGravarRegistro += servicoAluguel.Editar;

            telaDevolucao.ArrumarTela(aluguel);

            if (telaDevolucao.ShowDialog() == DialogResult.OK)
                CarregarItens();
        }
        public override void GerarPdf()
        {
            Teste testeSelecionado = ObterTesteSelecionado();

            if (testeSelecionado != null)
            {
                string diretorioTemporario = Path.GetTempPath();

                string caminhoArquivo = Path.Combine(diretorioTemporario, "teste.pdf");

                Document doc = new Document();

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminhoArquivo, FileMode.Create));

                doc.Open();

                doc.Add(new Paragraph($"ID do Teste: {testeSelecionado.id}"));
                doc.Add(new Paragraph($"Disciplina: {testeSelecionado.disciplina.nome}"));
                doc.Add(new Paragraph($"Matéria: {testeSelecionado.materia.nome}"));
                doc.Add(new Paragraph("Questões: \n--------------------------------------------------------------------------------------"));

                string letra = string.Empty;

                foreach (Questao questao in testeSelecionado.questoes)
                {
                    int contadorAlternativa = 0;
                    doc.Add(new Paragraph($"Titulo: {questao.titulo} \n"));

                    foreach (Alternativa alternativa in repositorioQuestoes.SelecionarAlternativas(questao))
                    {

                        if (contadorAlternativa == 0)
                            letra = "A) ";
                        else if (contadorAlternativa == 1)
                            letra = "B) ";
                        else if (contadorAlternativa == 2)
                            letra = "C) ";
                        else if (contadorAlternativa == 3)
                            letra = "D) ";

                        contadorAlternativa++;

                        doc.Add(new Paragraph($"{letra} {alternativa.alternativa}"));
                    }
                    doc.Add(new Paragraph($"--------------------------------------------------------------------------------------"));
                }


                doc.Close();

                MessageBox.Show("PDF do 'Teste' gerado com sucesso! \n'AppData/Local/Temp/teste.pdf'");
            }
        }
    }
}

