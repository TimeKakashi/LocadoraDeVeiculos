using LocadoraDeVeiculos.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.ModuloGrupoAutomovel
{
    public class ControladorGrupoAutomovel : ControladorBase
    {
        public override string ToolTipInserir => "Cadastrar Grupo de Automovel";

        public override string ToolTipEditar => "Editar Grupo de Automovel";

        public override string ToolTipExcluir => "Excluir Grupo de Automovel";

        public override string ToolTipFiltrar => "Filtrar Grupo de Automovel";

        public override string ToolTipPdf => "Gerar pdf do Grupo de Automovel";

        public override void CarregarItens()
        {
            throw new NotImplementedException();
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override void Inserir()
        {
            throw new NotImplementedException();
        }

        public override UserControl ObterTabela()
        {
            throw new NotImplementedException();
        }

        public override string ObterTipoCadastro()
        {
            throw new NotImplementedException();
        }
    }
}
