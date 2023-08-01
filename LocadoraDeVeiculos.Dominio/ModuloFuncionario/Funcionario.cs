using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
    }
}
