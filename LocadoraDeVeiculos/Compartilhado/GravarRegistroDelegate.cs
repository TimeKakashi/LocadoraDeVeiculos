using FluentResults;
using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Compartilhado
{
    public delegate Result GravarRegistroDelegate<T>(T item) where T : EntidadeBase<T>;
}
