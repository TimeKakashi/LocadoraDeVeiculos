using LocadoraDeVeiculos.Dominio.Combustivel;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.Acesso_por_JSON
{
    public class RepositorioCombustivel : JsonContext, IRepositorioCombustivelJson
    {
        private JsonContext ctx;
        public RepositorioCombustivel(JsonContext contexto)
        {
            this.ctx = contexto;
        }
        public void EditarValores(List<Combustivel> listaValores)
        {
            ctx.gasolina.valor = listaValores[0].valor;
            ctx.alcool.valor = listaValores[1].valor;
            ctx.gas.valor = listaValores[2].valor;
            ctx.disel.valor = listaValores[3].valor;

            ctx.CarregarArquivo();
        }
    }
}
