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
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Email { get; set; }

        // Atributos específicos para Pessoa Física
        public string CPF { get; set; }

        // Atributos específicos para Pessoa Jurídica
        public string CNPJ { get; set; }

        public Cliente(TipoCliente tipo, string nome, string telefone, string email, string bairro, string cidade, string estado, string numero, string rua, string cpfOuCnpj)
        {
            Tipo = tipo;
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Numero = numero;
            Rua = rua;

            if (Tipo == TipoCliente.PessoaFisica)
            {
                CPF = cpfOuCnpj;
            }
            else if (Tipo == TipoCliente.PessoaJuridica)
            {
                CNPJ = cpfOuCnpj;
            }
            else
            {
                throw new ArgumentException("Tipo de cliente inválido");
            }
        }

        public override void Atualizar(Cliente registro)
        {
            // Implementação do método Atualizar
            // ...
        }
    }






}
