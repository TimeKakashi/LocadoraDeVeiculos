using LocadoraDeVeiculos.Dominio.ModuloCupom;

namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public interface IRepositorioBase<T> where T : EntidadeBase<T>
    {
        void Inserir(T novoRegistro);

        void Editar(T registro);

        void Excluir(T registro);

        bool Existe(T registro);

        List<T> SelecionarTodos(bool Insercao = false, bool Insercao2 = false);

        T SelecionarPorId(Guid id);
        
    }
}
