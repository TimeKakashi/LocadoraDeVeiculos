using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCombustivel;
using System.Net;

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

            ctx.GravarTarefasEmArquivo();
        }

        public List<Combustivel> SelecionarTodos()
        {
            ctx.CarregarArquivo();

            return new List<Combustivel>
            {
                ctx.gasolina,
                ctx.alcool,
                ctx.gas,
                ctx.disel
            };
        }
    }
}
