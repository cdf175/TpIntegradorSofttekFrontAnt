using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TpIntegradorSofttekFront.Controllers
{
    [Authorize]
    public class WorkController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        public WorkController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult index()
        {
            return View();
        }

    }
}
