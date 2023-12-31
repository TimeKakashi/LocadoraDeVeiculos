﻿using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public interface IRepositorioCliente : IRepositorioBase<Cliente>
    {
        Cliente SelecionarPorNome(string nome);
        Cliente SelecionarPorCPF(string cpf);
        Cliente SelecionarPorCNPJ(string cnpj);
        List<Cliente> SelecionarTodos(bool Condutores = false, bool inutil = false);
    }

}
