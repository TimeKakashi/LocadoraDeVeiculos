﻿using SequentialGuid;

namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public abstract class EntidadeBase<T>
    {
        public Guid Id { get; set; }

        public EntidadeBase()
        {
            Id = SequentialGuidGenerator.Instance.NewGuid();
        }

    }
}
