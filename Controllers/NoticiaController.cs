using System.IO;
using Eplayers_AspNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eplayers_AspNet.Controllers
{
    [Route("Equipe")]
    public class NoticiaController : Controller
    {

        Noticia noticiaModel = new Noticia();
        [Route("Listar")]

        public IActionResult Index()
        {
            ViewBag.Noticias = noticiaModel.ReadAll();
            return View();
        }

        [Route("Cadastrar")]

        public IActionResult Cadastrar (IFormCollection form)
        {
            Noticia novaNoticia = new Noticia();
            novaNoticia.IdNoticia = noticiaModel.idNoticia();
            novaNoticia.Titulo = form["Titulo"];
            novaNoticia.Texto = form["Texto"];
            
            if(form.Files.Count > 0)
            {
                var file = form.Files[0];
                var folder = Path.Combine( Directory.GetCurrentDirectory(), "wwwroot/img/Noticias" );

                 if(!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                       
                var path = Path.Combine( Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);

                 using (var stream = new FileStream(path, FileMode.Create))
                {
                    // Salvamos o arquivo no caminho especificado
                    file.CopyTo(stream);
                }
                novaNoticia.Imagem = file.FileName;
            }

            else
            {
                novaNoticia.Imagem = "padrao.png";
            }
            noticiaModel.Create(novaNoticia);
            ViewBag.Noticias = noticiaModel.ReadAll();
            return LocalRedirect("~/Noticia/Listar");
        }

        [Route("{id}")]
        public IActionResult Excluir(int id)
        {
            noticiaModel.Delete(id);
            ViewBag.Noticias = noticiaModel.ReadAll();
            return LocalRedirect("~/Noticia/Listar");
        }
    }
}