using System.Collections.Generic;
using EPlayers_AspNet.Models;
using Eplayers_AspNet_Luaninha.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eplayers_AspNet_Luaninha.Controllers
{

    [Route("Login")]

    public class LoginController : Controller
    {

        [TempData]
        public string Mensagem { get; set; }
        
        Jogador jogadorModel = new Jogador();
        public IActionResult Index()
        {
            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form )
        {
           List<string> csv = jogadorModel.ReadAllLinesCSV("Database/Jogador.csv");

    // Verificamos se as informações passadas existe na lista de string
            var logado = 
            csv.Find(
                x => 
                x.Split(";")[3] == form["Email"] && 
                x.Split(";")[4] == form["Senha"]
            );

            // Redirecionamos o usuário logado caso encontrado
            if(logado != null)
            {
                HttpContext.Session.SetString("_UserName", logado.Split(";")[2]);
                return LocalRedirect("~/");
            }

            Mensagem = "Dados incorretos, tente novamente...";
            return LocalRedirect("~/Login");
        }

        [Route("Lougout")]
        public IActionResult Sair()
        {
            HttpContext.Session.Remove("_UserName");
            return LocalRedirect("~/");
        }
    }
}