﻿using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public class Condutor : EntidadeBase<Condutor>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string CNH { get; set; }
        public DateTime ValidadeCNH { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Guid ClienteId { get; set; } // Adicionando um campo para o ID do cliente associado

        public Condutor()
        {
            Id = Guid.NewGuid();
        }

        public Condutor(string nome, string cpf, string cnh, DateTime validadeCNH, string telefone, string email, Guid clienteId)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            CPF = cpf;
            CNH = cnh;
            ValidadeCNH = validadeCNH;
            Telefone = telefone;
            Email = email;
            ClienteId = clienteId;
        }

        public override void Atualizar(Condutor registro)
        {
            Nome = registro.Nome;
            CPF = registro.CPF;
            CNH = registro.CNH;
            ValidadeCNH = registro.ValidadeCNH;
            Telefone = registro.Telefone;
            Email = registro.Email;
            ClienteId = registro.ClienteId;
        }
    }



}