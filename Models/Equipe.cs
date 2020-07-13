using System;
using System.Collections.Generic;
using System.IO;
using E_players_Back_end.Interfaces;
using E_players_Back_end.Models;

namespace E_players_Back_end
{

    //interface por ultimo na herança

    /// <summary>
    /// Herança com 1 classe Base, e uma interface
    /// </summary>
    public class Equipe : EPlayersBase ,  IEquipe
    {
        public int IdTeam { get; set; }
        public string Name {get; set;}

        public string Image { get; set; }


        /// <summary>
        /// Criando a Pasta do csv com método construtor
        /// </summary>
        private const string PATH = "Database/Teams.csv";
        public Equipe(){
            CreateFolderAndFile(PATH);
        }

        public void Create(Equipe e)
        {
            string[] linhas = {PrepararLinha(e)};
            File.AppendAllLines(PATH, linhas);
        }

        private string PrepararLinha(Equipe e){
            return $"{e.IdTeam}; {e.Name}; {e.Image}";
        }

        public void Delete(int IdTeam)
        {
            List<string>linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(y => y.Split(";")[0] == IdTeam.ToString());
            RewriteCSV(PATH, linhas);
        }

        public List<Equipe> ReadAll()
        {
               List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();
                equipe.IdTeam = Int32.Parse(linha[0]);
                equipe.Name = linha[1];
                equipe.Image = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }



        public void Update(Equipe e)
        {
            List<string>linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(y => y.Split(";")[0] == e.IdTeam.ToString());
            linhas.Add( PrepararLinha(e) );
            RewriteCSV(PATH, linhas);
        }
    }
}