namespace LocadoraDeVeiculos.Compartilhado
{
    public abstract class ControladorBase
    {
        public abstract string ToolTipInserir { get; }
        public abstract string ToolTipEditar { get; }
        public abstract string ToolTipExcluir { get; }
        public abstract string ToolTipFiltrar { get; }
        public abstract string ToolTipPdf { get; }
        public abstract string ToolTipCombustivel { get; }

        public virtual bool InserirHabilitado { get { return true; } }
        public virtual bool EditarHabilitado { get { return true; } }
        public virtual bool ExcluirHabilitado { get { return true; } }
        public virtual bool VisualizarHabilitado { get { return false; } }
        public virtual bool GerarPdfHabilitado { get { return false; } }
        public virtual bool AtualizarValoresCombustivel { get { return false; } }

        public abstract void Inserir();
        public abstract void Editar();
        public abstract void Excluir();
        public virtual void GerarPdf() { }
        public abstract UserControl ObterTabela();
        public abstract string ObterTipoCadastro();
        public abstract void CarregarItens();
    }
}
