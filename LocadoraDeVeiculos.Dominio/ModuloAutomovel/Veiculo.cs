﻿using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using System.Drawing;
using System.Drawing.Imaging;

namespace LocadoraDeVeiculos.Dominio.ModuloAutomovel
{
    public class Veiculo : EntidadeBase<Veiculo>
    {
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
        public byte[] Imagem { get; set; }
        public decimal Kilometragem { get; set; }
        public string Placa { get; set; }
        public EnumCombusteivel EnumCombusteivel { get; set; }
        public int CapacidadeEmLitros { get; set; }
        public GrupoAutomovel GrupoAutomovel { get; set; }

        public bool EmUso { get; set; }
        public Veiculo()
        {

        }

        public Veiculo(string modelo, string marca, string cor, byte[] imagem, decimal kilometragem, string placa, EnumCombusteivel enumCombusteivel, int capacidadeEmLitros, GrupoAutomovel grupoAutomovel, bool emUso) : this(modelo)
        {
            Marca = marca;
            Cor = cor;
            Imagem = imagem;
            Kilometragem = kilometragem;
            Placa = placa;
            EnumCombusteivel = enumCombusteivel;
            CapacidadeEmLitros = capacidadeEmLitros;
            GrupoAutomovel = grupoAutomovel;
            EmUso = emUso;
        }

        public Veiculo(string modelo)
        {
            this.Modelo = modelo;
        }

        public Veiculo(string modelo, GrupoAutomovel grupo) : this(modelo)
        {
            this.GrupoAutomovel = grupo;
        }
        
        public Image ConverterArrBytesParaImagem(byte[] arrayBytes)
        {
            using (var imageStream = new MemoryStream(arrayBytes))
            {
                var image = Image.FromStream(imageStream);

                return image;
            }
        }

        public Image ConverterArrBytesParaImagem()
        {
            return ConverterArrBytesParaImagem(this.Imagem);
        }

        public byte[] ConverterImagemParaArrayByte(Image image)
        {
            using (var imagemStream = new MemoryStream())
            {
                image.Save(imagemStream, ImageFormat.Png);

                return imagemStream.ToArray();
            }
        }

        public override string ToString()
        {
            return Modelo;
        }

        public override bool Equals(object? obj)
        {
            return obj is Veiculo veiculo  && Id == veiculo.Id;
        }
    }




}
