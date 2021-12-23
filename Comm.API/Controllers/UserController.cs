using System;
using System.Text;
using System.Text.Json;
using Comm.API.Infrastructure;
using Comm.Model;
using Comm.Model.User;
using Comm.Service.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace Comm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IDistributedCache _distributedCache;
        public UserController(IUserService userService, IDistributedCache distributedCache)
        {
            _userService = userService;
            _distributedCache = distributedCache;
        }

        [HttpPost("/api/[controller]/register")]
        public Common<Model.User.User> Register([FromForm] User newUser)
        {
            return _userService.Register(newUser);
        }

        [HttpPost("/api/[controller]/login")]
        public IActionResult Login([FromBody] UserLogin user)
        {
            string json = JsonSerializer.Serialize(_userService.Login(user));
            var userFromCache = Encoding.UTF8.GetBytes(json);
            var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromDays(7)) // belirli bir süre erişilmemiş ise expire eder
                    .SetAbsoluteExpiration(DateTime.Now.AddMonths(1)); // belirli bir süre sonra expire eder.
            _distributedCache.SetAsync(key: "LoggedUser", userFromCache, options);
            return Ok(userFromCache);
        }

        [HttpGet("/api/[controller]/logout")]
        [ServiceFilter(typeof(LoginFilter))]
        public IActionResult Logout()
        {
            _distributedCache.RemoveAsync("LoggedUser");
            return Ok();
        }
    }
}