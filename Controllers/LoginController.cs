using EPlayers_AspNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eplayers_AspNet_Luaninha.Controllers
{

    [Route("Login")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            Jogador jogadorModel = new Jogador();
            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form )
        {
            return LocalRedirect("~/");
        }
    }
}