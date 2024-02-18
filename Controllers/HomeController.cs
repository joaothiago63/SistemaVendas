using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;
using SistemaVendas.Uteis;
using System.Diagnostics;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SistemaVendas.Controllers
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
            DAL obj = new DAL();
            // obj.ExecutarComandoSql("INSERT INTO VENDEDOR (nome, email, senha) values ('João','contato_joaothiago@hotmail.com','123456')");

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Sair()
        {
            HttpContext.Session.SetString("usuario", "");
            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Login(LoginModel login)
        {

            /*NÃO ESQUECER DE TIRAR A TAG REQUIRED DO HTML*/
            if (ModelState.IsValid)
            {
                if (login.ValidarLogin())
                {
                    UsuarioModel usuario = new UsuarioModel(login);
                    string json = JsonConvert.SerializeObject(usuario);
                    HttpContext.Session.SetString("usuario", json);
                    return RedirectToAction("Menu");
                }
                TempData["MsgErro"] = "Login Inválido";
                return View(login);
            }

            return View(login);
        }

        public IActionResult Menu()
        {


            return View();
        }





    }
}