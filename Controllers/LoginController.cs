using System.Security.Claims;
using Data.Base;
using Data.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TpIntegradorSofttekFront.Models;
using TpIntegradorSofttekFront.ViewModels;

namespace TpIntegradorSofttekFront.Controllers
{
	public class LoginController : Controller
	{
		private readonly IHttpClientFactory _httpClient;
        public LoginController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult Login()
		{
			//ClaimsPrincipal claimUser = HttpContext.User;
			//if(claimUser.Identity.IsAuthenticated)
			//{
   //             return RedirectToAction("Index", "Home");
   //         }

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Ingresar(LoginDto dto) 
		{
			var baseApi = new BaseApi(_httpClient);
			var response = await baseApi.PostToApi("Login", dto);
			var loginResult = response as OkObjectResult;
			if (loginResult == null)
			{
				ViewBag.ErrorLogin = "Usuario o clave inválidos.";
				//return View("~/Views/Login/Login.cshtml" );
				return RedirectToAction("Login", "Login");
			}
			var loginSuccess = JsonConvert.DeserializeObject<SuccessResponse<Login>>(loginResult.Value.ToString());
			Login login = loginSuccess.Data;

			var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme,ClaimTypes.Name,ClaimTypes.Role);
			Claim claimNombre = new(ClaimTypes.Name, login.Name);
            Claim claimRole = new(ClaimTypes.Role, login.Type.ToString());


			identity.AddClaim(claimNombre);
            identity.AddClaim(claimRole);
            

			ClaimsPrincipal principal = new ClaimsPrincipal(identity);

			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,new AuthenticationProperties
			{
				ExpiresUtc = DateTime.Now.AddHours(1),
			});
            
			HttpContext.Session.SetString("Token", login.Token);

            var homeViewModel = new HomeViewModel();
            homeViewModel.Token = login.Token;

			return View("~/Views/Home/Index.cshtml", homeViewModel);
			//return RedirectToAction("Index", "Home");
        }

		public async Task<IActionResult> CerrarSesion()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Login", "Login");
		}

	}
}
