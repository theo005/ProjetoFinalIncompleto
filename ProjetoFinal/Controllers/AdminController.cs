using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ProjetoFinal.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Produtos()
        {
            return View();
        }

        public IActionResult Categorias()
        {
            return View();
        }

        public IActionResult Clientes()
        {
            return View();
        }

        public IActionResult Pedidos()
        {
            return View();
        }
    }
}

