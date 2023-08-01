using FluentResults;
using LocadoraDeVeiculos.Aplicacao.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloGrupoAutomovel
{
    public class ServicoGrupoAutomovel : ServicoBase<GrupoAutomovel>
    {
        public override Result Inserir(GrupoAutomovel registro)
        {
            throw new NotImplementedException();
        }
        public override Result Editar(GrupoAutomovel registro)
        {
            throw new NotImplementedException();
        }

        public override Result Excluir(GrupoAutomovel registro)
        {
            throw new NotImplementedException();
        }

        protected override List<string> ValidarRegistro(GrupoAutomovel registro)
        {
            throw new NotImplementedException();
        }
    }
}
