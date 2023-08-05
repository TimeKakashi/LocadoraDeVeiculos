using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.Compartilhado
{
    public class LocadoraDeVeiculosDesignFactory : IDesignTimeDbContextFactory<LocadoraDeVeiculosDbContext>
    {
        public LocadoraDeVeiculosDbContext CreateDbContext(string[] args)
        {
            var configuracao = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            var optionsBuilder = new DbContextOptionsBuilder<LocadoraDeVeiculosDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new LocadoraDeVeiculosDbContext(optionsBuilder.Options);
        }
    }
}
