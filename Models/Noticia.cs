using System;
using System.Collections.Generic;
using System.IO;
using E_players_Back_end.Interfaces;

namespace E_players_Back_end.Models
{
    public class Noticia : EPlayersBase, INoticia
    {
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Image { get; set; }

        /// <summary>
        /// Criando a Pasta do csv com método construtor
        /// </summary>
        private const string PATH = "Database/Noticias.csv";
        public Noticia(){
            CreateFolderAndFile(PATH);
        }

        /// <summary>
        /// Aplicando métodos da interface
        /// </summary>
        /// <param name="n"></param>

        public void Create(Noticia n)
        {
            string[] linhas = {PrepararLinha(n)};
            File.AppendAllLines(PATH, linhas);
        }

        private string PrepararLinha(Noticia n){
            return $"{n.IdNoticia};{n.Titulo};{n.Texto};{n.Image}";
        }
        public void Update(Noticia n)
        {
            List<string>linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(y => y.Split(";")[0] == n.IdNoticia.ToString());
            linhas.Add( PrepararLinha(n) );
            RewriteCSV(PATH, linhas);
        }

        public void Delete(int IdNoticia)
        {
             List<string>linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(y => y.Split(";")[0] == IdNoticia.ToString());
            RewriteCSV(PATH, linhas);
        }

        public List<Noticia> ReadAll()
        {
               List<Noticia> noticias = new List<Noticia>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Noticia noticia = new Noticia();
                noticia.IdNoticia = Int32.Parse(linha[0]);
                noticia.Titulo = linha[1];
                noticia.Texto = linha[2];
                noticia.Image = linha[3];

                noticias.Add(noticia);
            }
            return noticias;
        }
    }
}