using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoFinal.Controllers
{
    public class InstrumentosController : Controller
    {

        private readonly HttpClient _httpClient;

        public InstrumentosController()
        {
            _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri("https://localhost:7140/api/");
        }
        public IActionResult index()
        {
            return View();
        }
        [Authorize(Roles = "ADMIN, Admin")]
        public IActionResult AdicionarInstrumentos()
        {
            return View();
        }
        public IActionResult Orgao()
        {
            return View();
        }
        public IActionResult Madeiras()
        {
            return View();
        }
        public IActionResult Metais()
        {
            return View();
        }
        public IActionResult Cordas()
        {
            return View();
        }
        public IActionResult Teclas()
        {
            return View();
        }
        public IActionResult Percussao()
        {
            return View();
        }

    }
}
