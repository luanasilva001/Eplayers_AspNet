using System;
using System.IO;
using EPlayers_AspNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayers_AspNet.Controllers
{
    // localhost: 5001/Equipe
    [Route("Equipe")]
    public class EquipeController : Controller
    {
        Equipe equipeModel = new Equipe();
        [Route("Listar")]
    
        public IActionResult Index()
        {
            // Equipe idAutomatico = new Equipe();
            // ViewBag.idAutomatico = idAutomatico.idEquipao();
            // Listando todas as equipes e enviando para a View, através da ViewBag
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }

        [Route("Cadastrar")]
        
        public IActionResult Cadastrar(IFormCollection form)
        {
            // Criamos uma nova instância de Equipe
            // e armazenamos os dados enviados pelo usúarios
            // através do formulário
            // e salvamos no objeto novaEquipe
            Equipe novaEquipe = new Equipe();
            novaEquipe.IdEquipe = equipeModel.idEquipao();
            novaEquipe.Nome = form["Nome"];
            
            // Inicio uploud
            if(form.Files.Count > 0 )
            {
                //Se sim,
                //Armazenamos o arquivo na variável file
                var file = form.Files[0];
                var folder = Path.Combine( Directory.GetCurrentDirectory(), "wwwroot/img/Equipes" );

                // Verificamos se a pasta Equipes não existe
                if(!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                                                    //localhost:5001           +        + Equipes + equipe.jpg        
                var path = Path.Combine( Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    // Salvamos o arquivo no caminho especificado
                    file.CopyTo(stream);
                }
                novaEquipe.Imagem = file.FileName;
            }

            else
            {
                novaEquipe.Imagem = "padrao.png";
            }
            // Uploud termino

            // Chamamos o método Create para salvar
            // a novaEquipe no CSV
            equipeModel.Create(novaEquipe); 
            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe/Listar");
        }

        [Route("{id}")]
        
        public IActionResult Excluir(int id)
        {
            equipeModel.Delete(id);
            ViewBag.Equipes = equipeModel.ReadAll();
            return LocalRedirect("~/Equipe/Listar");
        }
    }
}