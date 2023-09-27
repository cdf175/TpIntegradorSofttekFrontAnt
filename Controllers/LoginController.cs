using Data.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace TpIntegradorSofttekFront.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Login()
		{
			return View();
		}

		public IActionResult Ingresar(LoginDto dto) 
		{
			return View("~/Views/Home/Index.cshtml");
		}
	}
}
