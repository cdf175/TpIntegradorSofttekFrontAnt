using Data.Base;
using Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TpIntegradorSofttekFront.Models;

namespace TpIntegradorSofttekFront.Controllers
{
	public class ServiceController : Controller
	{
		private readonly IHttpClientFactory _httpClient;
		public ServiceController(IHttpClientFactory httpClient)
		{
			_httpClient = httpClient;
		}
		public IActionResult index()
		{
			return View();
		}

	}
}
