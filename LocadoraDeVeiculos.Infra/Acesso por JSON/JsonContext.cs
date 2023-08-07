using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloCombustivell;
using LocadoraDeVeiculos.Dominio.ModuloCombustivel;

namespace LocadoraDeVeiculos.Infra.Orm.Acesso_por_JSON
{
    public class JsonContext
    {
        public const string NOME_ARQUIVO = "jsonCombustiveis.json";

        public Gasolina gasolina;
        public Disel disel;
        public Gas gas;
        public Alcool alcool;

        public JsonContext()
        {
        }

        public JsonContext(bool carregarDados) : this()
        {
            if (File.Exists(NOME_ARQUIVO) == false)
            {
                Serilog.Log.Error("Arquivo json nao existe!");
                return;
            }

            CarregarArquivo();
        }

        public void GravarTarefasEmArquivo()
        {
            JsonSerializerOptions config = ObterConfiguracoes();

            string strJason = JsonSerializer.Serialize(this, config);

            File.WriteAllText(NOME_ARQUIVO, strJason);
        }

        public void CarregarArquivo()
        {
            JsonSerializerOptions config = ObterConfiguracoes();

            if (File.Exists(NOME_ARQUIVO))
            {
                string strJson = File.ReadAllText(NOME_ARQUIVO);

                if (strJson.Length > 0)
                {
                    JsonContext ctx = JsonSerializer.Deserialize<JsonContext>(strJson, config);

                    this.gasolina = ctx.gasolina;
                    this.disel = ctx.disel;
                    this.gas = ctx.gas;
                    this.alcool = ctx.alcool;
                }
            }
        }

        private static JsonSerializerOptions ObterConfiguracoes()
        {
            JsonSerializerOptions opcoes = new JsonSerializerOptions();
            opcoes.IncludeFields = true;
            opcoes.WriteIndented = true;
            opcoes.ReferenceHandler = ReferenceHandler.Preserve;

            return opcoes;
        }
    }
}
