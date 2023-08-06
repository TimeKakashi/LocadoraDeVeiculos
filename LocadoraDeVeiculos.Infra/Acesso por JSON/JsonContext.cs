﻿using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.Combustivel;

namespace LocadoraDeVeiculos.Infra.Orm.Acesso_por_JSON
{
    public class JsonContext
    {
        public const string NOME_ARQUIVO = "4.Infra\\jsconfig1.json";

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
                //File.Create(NOME_ARQUIVO);
                File.Create("").ToString();
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
