using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase<Funcionario>
    {
        public string Nome { get; set; }
        public DateTime DataEntrada { get; set; }
        public decimal Salario { get; set; }

        public Funcionario()
        {

        }
        public Funcionario(string nome, decimal salario, DateTime data)
        {
            this.Nome = nome;
            this.Salario = salario;
            this.DataEntrada = data;
        }

        public Funcionario(Guid id, string nome, decimal salario, DateTime data) : this(nome, salario, data)
        {
            this.Id = id;
        }

        public override void Atualizar(Funcionario registro)
        {
            this.Nome = registro.Nome;
            this.DataEntrada = registro.DataEntrada;
            this.Salario = registro.Salario;
        }

        public override string ToString()
        {
            return this.Nome;
        }

        public override bool Equals(object obj)
        {
            return obj is Funcionario funcionario &&
                   Id == funcionario.Id &&
                   Nome == funcionario.Nome;
        }
    }
}
