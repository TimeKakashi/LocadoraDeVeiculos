using FluentResults;
using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Aplicacao.Compartilhado
{
    public abstract class ServicoBase<T> where T : EntidadeBase<T>
    {
        public abstract Result Inserir(T registro);
        public abstract Result Editar(T registro);
        public abstract Result Excluir(T registro);
        protected abstract List<string> ValidarRegistro(T registro);
        protected virtual bool NomeDuplicado(T registro) => false;
    }
}
