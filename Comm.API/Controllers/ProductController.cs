using System.Collections.Generic;
using System.Text.Json;
using Comm.API.Infrastructure;
using Comm.Model;
using Comm.Model.Pagination;
using Comm.Service.Email;
using Comm.Service.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace Comm.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IDistributedCache _distributedCache;
        private readonly HangfireJobs _hangfireJobs;
        public ProductController(IProductService productService, IDistributedCache distributedCache, IEmailService emailService)
        {
            _productService = productService;
            _distributedCache = distributedCache;
            _hangfireJobs = new HangfireJobs(emailService);
        }

        [HttpGet("/api/[controller]")]
        public IActionResult ProductList([FromQuery] PaginationParameters pagination
        , [FromQuery] string sortBy, [FromQuery] string searchString)
        {
            _hangfireJobs.SendWelcomeMail("ontatakan", "SendToUser@hotmail.com");
            var result = JsonSerializer.Serialize(_productService.GetProducts(pagination, sortBy, searchString));
            return Ok(result);
        }

        [HttpGet("/api/[controller]/{id}")]
        public IActionResult GetProduct(int id)
        {
            var result = JsonSerializer.Serialize(_productService.Get(id).Entity);
            return Ok(result);
        }

        [HttpPost("/api/[controller]")]
        [ServiceFilter(typeof(LoginFilter))]
        public IActionResult AddProduct([FromBody] Model.Product.Product newProduct)
        {
            return Ok(_productService.Add(newProduct).Entity);
        }

        [HttpPut("/api/[controller]/{id}")]
        [ServiceFilter(typeof(LoginFilter))]
        public IActionResult UpdateProduct([FromBody] Model.Product.Product updatedProduct)
        {
            var result = _productService.Update(updatedProduct);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}