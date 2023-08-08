using FluentResults;
using LocadoraDeVeiculos.Aplicacao.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloAluguel
{
    internal class ServicoAluguel : ServicoBase<Aluguel>
    {
        public override Result Editar(Aluguel registro)
        {
            throw new NotImplementedException();
        }

        public override Result Excluir(Aluguel registro)
        {
            throw new NotImplementedException();
        }

        public override Result Inserir(Aluguel registro)
        {
            throw new NotImplementedException();
        }

        protected override List<string> ValidarRegistro(Aluguel registro)
        {
            throw new NotImplementedException();
        }
    }
}
