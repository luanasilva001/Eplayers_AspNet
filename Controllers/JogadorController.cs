
using System.IO;
using EPlayers_AspNet.Models;
using Eplayers_AspNet_Luaninha.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eplayers_AspNet_Luaninha.Controllers
{
    [Route("Jogador")]
    public class JogadorController : Controller
    {
        Jogador jogadorModel = new Jogador();
        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Jogadores = jogadorModel.ReadAll();

            Equipe novalistagemdaequipe = new Equipe();
            ViewBag.novalistagemdaequipe = novalistagemdaequipe.ReadAll();
            return View();
        }
        
        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection formJogador)
        {
            Jogador novoJogador = new Jogador();
            novoJogador.IdJogador = jogadorModel.idJogadores();
            novoJogador.Nome = formJogador["Nome"];
            novoJogador.Email = formJogador["Email"];
            novoJogador.Senha = formJogador["Senha"];

            jogadorModel.Create(novoJogador);
            ViewBag.Jogadores = jogadorModel.ReadAll();
            return LocalRedirect("~/Jogador/Listar");
        }

        [Route("{id}")]
        public  IActionResult Excluir (int id)
        {
            jogadorModel.Delete(id);
            ViewBag.Jogadores = jogadorModel.ReadAll();
            return LocalRedirect("~/Jogador/Listar");
        }
    }
}