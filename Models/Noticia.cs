using System;
using System.Collections.Generic;
using System.IO;
using E_players_Back_end.Interfaces;

namespace E_players_Back_end.Models
{
    public class Noticia : EPlayersBase, INoticia
    {
        public int IdNews { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }

        /// <summary>
        /// Criando a Pasta do csv com método construtor
        /// </summary>
        private const string PATH = "Database/News.csv";
        public Noticia(){
            CreateFolderAndFile(PATH);
        }

        public void Create(Noticia n)
        {
            string[] linhas = {PrepararLinha(n)};
            File.AppendAllLines(PATH, linhas);
        }

        private string PrepararLinha(Noticia n){
            return $"{n.IdNews}; {n.Title}; {n.Text}; {n.Image}";
        }
        public void Update(Noticia n)
        {
            List<string>linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(y => y.Split(";")[0] == n.IdNews.ToString());
            linhas.Add( PrepararLinha(n) );
            RewriteCSV(PATH, linhas);
        }

        public void Delete(int IdNews)
        {
             List<string>linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(y => y.Split(";")[0] == IdNews.ToString());
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
                noticia.IdNews = Int32.Parse(linha[0]);
                noticia.Title = linha[1];
                noticia.Text = linha[2];
                noticia.Image = linha[3];

                noticias.Add(noticia);
            }
            return noticias;
        }
    }
}