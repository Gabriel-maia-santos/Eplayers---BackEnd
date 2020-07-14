using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using E_players_Back_end;

namespace E_Players.Controllers
{
    public class EquipeController : Controller
    {

        Equipe equipeModel = new Equipe();
        public IActionResult Index()
        {
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }

        public IActionResult Cadastrar(IFormCollection form){

            Equipe equipe = new Equipe();

            equipe.IdTeam = Int32.Parse(form["IdTeam"]);
            equipe.Name = form["Name"];
            equipe.Image = form["image"];


            equipeModel.Create(equipe);
            ViewBag.Equipes = equipeModel.ReadAll();

              return LocalRedirect("~/Equipe");
        }
    }
}