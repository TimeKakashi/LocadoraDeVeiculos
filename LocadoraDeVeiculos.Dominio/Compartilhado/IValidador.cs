using FluentValidation.Results;

namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public interface IValidador<T> where T : EntidadeBase<T>
    {
        public ValidationResult Validate(T registro);
    }
}
