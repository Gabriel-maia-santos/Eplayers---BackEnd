using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using E_players_Back_end.Models;
using System.IO;
using E_players_Back_end;

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

        public IActionResult CadastrarNoticia(IFormCollection form){

            Noticia noticia = new Noticia();

            noticia.IdNews = Int32.Parse(form["IdNews"]);
            noticia.Title = form["Title"];
            noticia.Text = form["Text"];
            
            //Upload da imagem
            var file    = form.Files[0];
            var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/News");

            if(file != null)
            {
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                //Arquivo.jpg
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);
                }
                noticia.Image   = file.FileName;
            }
            else
            {
                noticia.Image   = "padrao.png";
            }
            //Fim do upload


            noticiaModel.Create(noticia);


              return LocalRedirect("~/New");
        }

        //Excluir arquivo
         [Route("[controller]/{id}")]
         public IActionResult Excluir(int id){
            noticiaModel.Delete(id);
            return LocalRedirect("~/Noticias");
         }
    
    }

}