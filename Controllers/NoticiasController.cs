using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using E_players_Back_end.Models;

namespace E_Players.Controllers
{
    public class NoticiasController : Controller
    {
        Noticia noticiaModel = new Noticia();
        public IActionResult Index()
        {
            ViewBag.Noticia = noticiaModel.ReadAll();
            return View();
        }

        public IActionResult Cadastrar(IFormCollection form){

            Noticia noticia = new Noticia();

            noticia.IdNews = Int32.Parse(form["IdNews"]);
            noticia.Title = form["Title"];
            noticia.Text = form["Text"];
            noticia.Image = form["image"];


            noticiaModel.Create(noticia);
            ViewBag.Noticia = noticiaModel.ReadAll();

              return LocalRedirect("~/Noticia");
        }
    }
}