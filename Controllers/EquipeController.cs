using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using E_players_Back_end;
using System.IO;

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


            //Upload da imagem
            var file    = form.Files[0];
            var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

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
                equipe.Image   = file.FileName;
            }
            else
            {
                equipe.Image   = "padrao.png";
            }
            //fim do upload

            equipeModel.Create(equipe);

            return LocalRedirect("~/Equipe");


        }

        [Route("[controller]/{id}")]


        /// <summary>
        /// Excluindo uma equipe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Excluir(int id){
            equipeModel.Delete(id);
            return LocalRedirect("~/Equipe");
        }

    }
}