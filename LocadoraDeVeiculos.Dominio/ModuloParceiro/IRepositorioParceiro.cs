﻿using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloParceiro
{
    public interface IRepositorioParceiro : IRepositorioBase<Parceiro>
    {
        Parceiro SelecionarPorNome(string nome);
    }
}