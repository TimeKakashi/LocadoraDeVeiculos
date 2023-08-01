using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class Cliente : EntidadeBase<Cliente>
    {
        public enum TipoCliente
        {
            PessoaFisica,
            PessoaJuridica
        }

        public TipoCliente Tipo { get; private set; }

        // Atributos comuns a Pessoa Física e Jurídica
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }

        // Atributos específicos para Pessoa Física
        public string CPF { get; set; }
        public string RG { get; set; }
        public string CNH { get; set; }
        public Cliente PessoaJuridicaAssociada { get; set; } // Referência à Pessoa Jurídica associada, pode ser nulo

        // Atributos específicos para Pessoa Jurídica
        public string CNPJ { get; set; }
        public string CondutorCPF { get; set; }

        public Cliente(string nome, string telefone, Endereco endereco, string cpf, string rg, string cnh)
        {
            Tipo = TipoCliente.PessoaFisica;
            Nome = nome;
            Telefone = telefone;
            Endereco = endereco;
            CPF = cpf;
            RG = rg;
            CNH = cnh;
        }

        public Cliente(string nome, string telefone, Endereco endereco, string cnpj, string condutorCpf)
        {
            Tipo = TipoCliente.PessoaJuridica;
            Nome = nome;
            Telefone = telefone;
            Endereco = endereco;
            CNPJ = cnpj;
            CondutorCPF = condutorCpf;
        }

        public override void Atualizar(Cliente registro)
        {
            throw new NotImplementedException();
        }
    }

    public class Endereco
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
    }
}
