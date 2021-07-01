using System;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        //Atributos
        private Genero Genero {get; set; }
        private string Titulo {get; set; }
        private string Descricao {get; set; }
        private int Ano {get; set; }
        private bool Excluido {get; set; }

        //Métodos
        public Serie (int id, Genero genero, string titulo, string descricao, int ano){
            this.Id = id;                   //receber o valor de id
            this.Genero = genero;           //receber o valor de genero
            this.Titulo = titulo;           //receber o valor de titulo
            this.Descricao = descricao;     //receber o valor de descricao
            this.Ano = ano;                 //receber o valor de ano
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Inicio: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        //Retorna o dado do Titulo
        public string retornaTitulo(){
            return this.Titulo;
        }

        //Retorna a informação se está excluido ou não
        public bool retornaExcluido(){
            return this.Excluido;
        }

        //Retorna o dado do Id
         public int retornaId(){
            return this.Id;
        }

        public void Excluir(){
            this.Excluido = true;
        }

    }
}