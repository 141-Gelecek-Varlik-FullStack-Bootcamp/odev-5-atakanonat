using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Distributed;

namespace Comm.API.Infrastructure
{
    public class LoginFilter : Attribute, IActionFilter
    {
        public int MaxRequestPerSecond { get; set; } = 3;
        private readonly IDistributedCache _distributedCache;
        public LoginFilter(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var userLog = _distributedCache.GetAsync(key: "LoggedUser");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var userFromCache = _distributedCache.GetAsync(key: "LoggedUser");
            userFromCache.Wait();
            if (userFromCache.Result is null)
            {
                context.HttpContext.Response.Redirect("https://localhost:5003/User/login");
            }
        }
    }
}