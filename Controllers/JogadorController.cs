
using System.IO;
using EPlayers_AspNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayers_AspNet.Controllers
{
    [Route("Jogador")]
    public class JogadorController : Controller
    {
        Jogador jogadorModel = new Jogador();
        [Route("Listar")]

        public IActionResult Index()
        {
            ViewBag.Jogadores = jogadorModel.ReadAll();

            Equipe novaListagemdaEquipe = new Equipe();
            ViewBag.novaListagemdaEquipe = novaListagemdaEquipe.ReadAll();
            return View();
        }


        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection formJogador)
        {
            Jogador novoJogador = new Jogador();
            novoJogador.IdJogador = int.Parse(formJogador["idJogador"]);
            novoJogador.IdEquipe = int.Parse(formJogador["idEquipe"]);
            novoJogador.Nome = formJogador["Nome"];

            jogadorModel.Create(novoJogador);
            ViewBag.Jogadores = jogadorModel.ReadAll();

            return LocalRedirect("~/Jogador/Listar");
        }

        [Route("{id}")]
        // [Route({"id"})]

        public IActionResult Excluir(int id)
        {
            jogadorModel.Delete(id);
            ViewBag.Jogadores = jogadorModel.ReadAll();
            return LocalRedirect("~/Jogador/Listar");
        }
    }
}