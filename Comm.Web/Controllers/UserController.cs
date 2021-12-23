using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Comm.Web.Infrastructure;
using Comm.Model.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Comm.API.Controllers
{
    public class UserController : Controller
    {
        public UserController()
        {
        }

        [HttpGet("/[controller]/register")]
        public IActionResult RegisterForm()
        {
            return View();
        }

        // [HttpPost("/[controller]/register")]
        // public IActionResult Register([FromForm] User newUser)
        // {
        //     var result = userService.Register(newUser);
        //     return Redirect("/User/login");
        // }

        [HttpGet("/[controller]/login")]
        public IActionResult LoginForm()
        {
            return View();
        }

        [HttpPost("/[controller]/login")]
        public IActionResult Login([FromForm] UserLogin user)
        {
            using (var client = new HttpClient())
            {
                var content = JsonContent.Create(user);
                var postTask = client.PostAsync("https://localhost:5001/api/User/login", content);
                postTask.Wait();
                var response = postTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("", "Product");
                }
            }
            return RedirectToAction("login", "User");
        }

        [HttpGet("/[controller]/logout")]
        [ServiceFilter(typeof(LoginFilter))]
        public IActionResult Logout()
        {
            using (var client = new HttpClient())
            {
                var getTask = client.GetAsync("https://localhost:5001/api/User/logout");
                getTask.Wait();
                return RedirectToAction("", "Product");
            }
        }
    }
}