using Data.Base;
using Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TpIntegradorSofttekFront.Models;

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
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Ingresar(LoginDto dto) 
		{
			var baseApi = new BaseApi(_httpClient);
			var response = await baseApi.PostToApi("Login", dto);
			var loginResult = response as OkObjectResult;
			var loginSuccess = JsonConvert.DeserializeObject<SuccessResponse<Login>>(loginResult.Value.ToString());
			Login login = loginSuccess.Data;

			return View("~/Views/Home/Index.cshtml",login);
		}

	}
}
