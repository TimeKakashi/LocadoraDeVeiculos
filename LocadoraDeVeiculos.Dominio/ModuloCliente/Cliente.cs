using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;

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

        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Email { get; set; }
        public List<Condutor> Condutores { get; set; } = new List<Condutor>();


        public string? CPF { get; set; }


        public string? CNPJ { get; set; }
        public Cliente()
        {

        }

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

        public override string ToString()
        {
            return Nome;
        }

        public override bool Equals(object? obj)
        {
            return obj is Cliente clinte &&
                Id == clinte.Id;
        }
    }






}
