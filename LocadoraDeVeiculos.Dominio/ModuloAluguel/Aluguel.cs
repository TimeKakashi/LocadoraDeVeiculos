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
        public Cupom? Cupom { get; set; }
        public Condutor Condutor { get; set; }
        public Veiculo Veiculo { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucaoPrevista { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public List<TaxaServico> TaxasServico { get; set; } = new List<TaxaServico>();
        public EnumNivelTanque? NivelTanque { get; set; }
        public decimal Preco { get; set; }
        public bool Finalizado { get; set; }
        public int? KmPercorrido { get; set; }

        public Aluguel()
        {
            
        }
        public Aluguel(
           Funcionario funcionario,Cliente cliente,GrupoAutomovel grupo,PlanoCobranca plano,Veiculo automovel,
           ModuloCupom.Cupom cupom, DateTime dataLocacao, DateTime dataPrevisao,decimal preco, bool finalizado, Condutor condutor) : this()
        {
            Funcionario = funcionario;
            Cliente = cliente;
            GrupoAutomovel = grupo;
            PlanoCobranca = plano;
            Veiculo = automovel;
            Cupom = cupom;
            DataLocacao = dataLocacao;
            DataDevolucaoPrevista = dataPrevisao;
            Preco = preco;
            Finalizado = finalizado;
            Condutor = condutor;
        }

        public Aluguel(
            Guid id,Funcionario funcionario, Cliente cliente, GrupoAutomovel grupo, PlanoCobranca plano,Veiculo automovel,
            ModuloCupom.Cupom cupom, int kmAutomovel, DateTime dataLocacao, DateTime dataPrevisao, decimal preco, bool finalziado, Condutor condutor) : 
            this(funcionario, cliente, grupo, plano, automovel, cupom, dataLocacao, dataPrevisao, preco, finalziado, condutor)
        {
            Id = id;
        }

        public decimal CalcularValorPorPlanoDiario()
        {
            TimeSpan diferenca = (TimeSpan)(DataDevolucao - DataLocacao);
            int diferencaDias = (int)diferenca.TotalDays;

            return (decimal)((diferencaDias * PlanoCobranca.ValorDiaria) + (KmPercorrido * PlanoCobranca.PrecoKm));
        }

        public decimal CalcularValorPorPlanoControlado()
        {
            TimeSpan diferenca = (TimeSpan)(DataDevolucao - DataLocacao);
            int diferencaDias = (int)diferenca.TotalDays;

            int kmExtrapolado = 0;

            if (KmPercorrido > PlanoCobranca.KmDisponivel)
            {
                kmExtrapolado = (int)(KmPercorrido - PlanoCobranca.KmDisponivel);
            }

            return (decimal)((diferencaDias * PlanoCobranca.ValorDiaria) + (kmExtrapolado * PlanoCobranca.PrecoKm));
        }

        public decimal CalcularValorParaPlanoLivre()
        {
            TimeSpan diferenca = (TimeSpan)(DataDevolucao - DataLocacao);
            int diferencaDias = (int)diferenca.TotalDays;

            return (decimal)(diferencaDias * PlanoCobranca.ValorDiaria);
        }

        public decimal CalcularValorPorPlano()
        {
            if (PlanoCobranca.Plano == planoCobranca.Diaria)
                return CalcularValorPorPlanoDiario();

            else if (PlanoCobranca.Plano == planoCobranca.Controlado)
                return CalcularValorPorPlanoControlado();

            else
                return CalcularValorParaPlanoLivre();

        }

        public decimal CalcularValorMulta()
        {
            if (DataDevolucao > DataDevolucaoPrevista)
            {
                var qtdDiasAtrasados = (int)(DataDevolucao - DataDevolucaoPrevista)?.TotalDays;
                decimal valorDiariaMulta = qtdDiasAtrasados * 50;

                valorDiariaMulta += Preco * 0.1m;

                return valorDiariaMulta;
            }

            return 0;
        }

        public decimal CalcularQuanidadeLitrosUsados()
        {
            decimal quantidadeLitrosUsados = 0;

            if (NivelTanque == EnumNivelTanque.Vazio)
            {
                quantidadeLitrosUsados = Veiculo.CapacidadeEmLitros * 1;
            }

            else if (NivelTanque == EnumNivelTanque.Baixo)
            {
                quantidadeLitrosUsados = Veiculo.CapacidadeEmLitros * 0.25m;
            }

            else if (NivelTanque == EnumNivelTanque.Medio)
            {
                quantidadeLitrosUsados = Veiculo.CapacidadeEmLitros * 0.5m;
            }

            else if (NivelTanque == EnumNivelTanque.Alto)
            {
                quantidadeLitrosUsados = Veiculo.CapacidadeEmLitros * 0.75m;
            }

            else if (NivelTanque == EnumNivelTanque.Cheio)
            {
                quantidadeLitrosUsados = 0;
            }

            return quantidadeLitrosUsados;
        }

        public decimal CalcularValorTotalSemGasolina()
        {
            decimal valorTotal = 0;

            valorTotal += CalcularValorPorPlano();

            valorTotal += CalcularValorMulta();

            return valorTotal;
        }
    }
}
