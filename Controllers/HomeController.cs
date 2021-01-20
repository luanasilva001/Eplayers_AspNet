using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EPlayers_AspNet.Models;
using Microsoft.AspNetCore.Http;
using Eplayers_AspNet.Models;

namespace EPlayers_AspNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Noticia noticiaModel = new Noticia();
            ViewBag.Noticias = noticiaModel.ReadAll();
            ViewBag.UserName = HttpContext.Session.GetString("_UserName"); 
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        }
    }
