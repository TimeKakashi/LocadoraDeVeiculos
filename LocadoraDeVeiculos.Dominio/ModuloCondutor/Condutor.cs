﻿using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public class Condutor : EntidadeBase<Condutor>
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string CNH { get; set; }
        public DateTime ValidadeCNH { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Cliente Cliente { get; set; }
        public bool ClienteEhCondutor { get; set; }

        public Condutor()
        {
            
        }
        public Condutor(string nome, string cpf, string cnh, DateTime validadeCNH, string telefone, string email)
        {
            Nome = nome;
            CPF = cpf;
            CNH = cnh;
            ValidadeCNH = validadeCNH;
            Telefone = telefone;
            Email = email;
        }

        public override string ToString()
        {
            return Nome;
        }

        public override bool Equals(object? obj)
        {
            return obj is Condutor condutor && Id == condutor.Id;
        }


    }




}
