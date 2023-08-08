using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;

namespace LocadoraDeVeiculos.Dominio.ModuloAluguel
{
    public class Aluguel : EntidadeBase<Aluguel>
    {
        public Funcionario Funcionario { get; set; }
        public Cliente Cliente { get; set; }
        public GrupoAutomovel GrupoAutomovel { get; set; }
        public PlanoCobranca PlanoCobranca { get; set; }
        public Cupom Cupom { get; set; }
        public Condutor Condutor { get; set; }
        public Veiculo Veiculo { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucaoPrevista { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public List<TaxaServico> TaxasServico { get; set; } = new List<TaxaServico>();
        public EnumNivelTanque NivelTanque { get; set; }
        public decimal Preco { get; set; }
        public bool Finalizado { get; set; }
        public int KmPercorrido { get; set; }

        public Aluguel()
        {
            
        }
        public Aluguel(
           Funcionario funcionario,Cliente cliente,GrupoAutomovel grupo,PlanoCobranca plano,Veiculo automovel,
           Cupom cupom, DateTime dataLocacao, DateTime dataPrevisao) : this()
        {
            Funcionario = funcionario;
            Cliente = cliente;
            GrupoAutomovel = grupo;
            PlanoCobranca = plano;
            Veiculo = automovel;
            Cupom = cupom;
            DataLocacao = dataLocacao;
            DataDevolucaoPrevista = dataPrevisao;
        }

        public Aluguel(
            Guid id,Funcionario funcionario, Cliente cliente, GrupoAutomovel grupo, PlanoCobranca plano,Veiculo automovel,
            Cupom cupom, int kmAutomovel, DateTime dataLocacao, DateTime dataPrevisao) : 
            this(funcionario, cliente, grupo, plano, automovel, cupom, dataLocacao, dataPrevisao)
        {
            Id = id;
        }
    }
}
