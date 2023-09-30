using Data.Base;
using Data.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using TpIntegradorSofttekFront.ViewModels;

namespace TpIntegradorSofttekFront.Controllers
{
    [Authorize]
    public class UserController:Controller
    {
        private readonly IHttpClientFactory _httpClient;
        public UserController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UserAddPartial([FromBody] UserDto user)
        {
            var userViewModel = new UserViewModel();
            if (user != null)
            {
                userViewModel = user;
            }

            return PartialView("~/Views/User/Partial/UserAddPartial.cshtml", userViewModel);
        }

        public IActionResult SaveUser(UserDto user)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);

            if (user.Id == 0)
            {
                var users = baseApi.PostToApi("user/create", user, token);
            }
            else
            {
                var users = baseApi.PutToApi("user/update/" + user.Id, user, token);
            }
            

            return View("~/Views/User/Index.cshtml");
        }

        public async Task<IActionResult> UserDeletePartial([FromBody] UserDto user)
        {
            var userViewModel = new UserViewModel();
            if (user != null)
            {
                userViewModel = user;
            }

            return PartialView("~/Views/User/Partial/UserDeletePartial.cshtml", userViewModel);
        }
        public IActionResult DeleteUser( UserDto user) {

            if (user != null)
            {
                var token = HttpContext.Session.GetString("Token");
                var baseApi = new BaseApi(_httpClient);
                var users = baseApi.DeleteToApi("user/delete/" + user.Id, token);
            }
            
            return View("~/Views/User/Index.cshtml");
            //return PartialView("~/Views/User/Partial/UserDeletePartial.cshtml");
            // return RedirectToAction("Index", "User");
        }
    }
}
