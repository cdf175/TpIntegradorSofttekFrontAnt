using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TpIntegradorSofttekFront.Controllers
{
    [Authorize]
    public class ProyectController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        public ProyectController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult index()
        {
            return View();
        }

    }
}
