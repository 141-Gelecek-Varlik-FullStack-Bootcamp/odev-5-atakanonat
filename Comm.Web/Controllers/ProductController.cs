using System;
using Comm.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text.Json;
using Comm.Model.Pagination;
using System.Collections.Generic;
using System.Text;
using Comm.Web.Infrastructure;

namespace Comm.API.Controllers
{
    public class ProductController : Controller
    {
        private readonly string apiBaseUrl;
        private readonly IConfiguration configuration;
        public ProductController(IConfiguration _configuration)
        {
            configuration = _configuration;
            apiBaseUrl = configuration.GetValue<string>("WebAPIBaseUrl");
        }

        [HttpGet("/[controller]")]
        public IActionResult ProductList([FromQuery] PaginationParameters pagination
        , [FromQuery] string sortBy, [FromQuery] string searchString)
        {
            using (var client = new HttpClient())
            {
                var uri = new Uri("https://localhost:5001/api/Product/" + "?" + "pageSize=" + pagination.PageSize);
                var responseTask = client.GetAsync(string.Format("https://localhost:5001/api/Product?pageSize={0}&pageNumber={1}&searchString={2}&sortBy={3}", pagination.PageSize, pagination.PageNumber, searchString, sortBy));
                responseTask.Wait();
                var response = responseTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync();
                    readTask.Wait();
                    var result = JsonSerializer.Deserialize<Common<List<Model.Product.Product>>>(readTask.Result);
                    ViewBag.Products = result.Entity;
                    if (pagination.PageNumber > result.TotalPages)
                    {
                        return RedirectToAction("", new { pageNumber = result.TotalPages, pageSize = pagination.PageSize });
                    }
                    else if (pagination.PageSize > result.TotalEntity)
                    {
                        return RedirectToAction("", new { pageNumber = 1, pageSize = result.TotalEntity });
                    }
                }
                else
                {
                    ViewBag.StatusCode = response.StatusCode;
                }
            }
            return View();
        }

        [HttpGet("/[controller]/{id}")]
        public IActionResult GetProduct(int id)
        {
            using (var client = new HttpClient())
            {
                var responseTask = client.GetAsync("https://localhost:5001/api/Product/" + id.ToString());
                responseTask.Wait();
                var response = responseTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync();
                    readTask.Wait();
                    ViewBag.Product = JsonSerializer.Deserialize<Model.Product.Product>(readTask.Result);
                }
                else
                {
                    ViewBag.StatusCode = response.StatusCode;
                }
            }
            return View();
        }

        [HttpGet("/[controller]/add")]
        [ServiceFilter(typeof(LoginFilter))]
        public IActionResult ProductAddForm()
        {
            return View();
        }

        [HttpPost("/[controller]")]
        [ServiceFilter(typeof(LoginFilter))]
        public IActionResult AddProduct([FromForm] Model.Product.Product newProduct)
        {
            using (var client = new HttpClient())
            {
                var stringContent = new StringContent(JsonSerializer.Serialize(newProduct), Encoding.UTF8, "application/json");
                var postTask = client.PostAsync("https://localhost:5001/api/Product/", stringContent);
                postTask.Wait();
                var response = postTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("", new { id = response });
                }
            }

            return RedirectToAction("");
        }

        [HttpGet("/[controller]/{id}/update")]
        [ServiceFilter(typeof(LoginFilter))]
        public IActionResult ProductUpdateForm(int id)
        {
            using (var client = new HttpClient())
            {
                var responseTask = client.GetAsync("https://localhost:5001/api/Product/" + id.ToString());
                responseTask.Wait();
                var response = responseTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync();
                    readTask.Wait();
                    ViewBag.Product = JsonSerializer.Deserialize<Model.Product.Product>(readTask.Result);
                }
                else
                {
                    ViewBag.StatusCode = response.StatusCode;
                }
            }
            return View();
        }

        [HttpPost("/[controller]/{id}")]
        [ServiceFilter(typeof(LoginFilter))]
        public IActionResult UpdateProduct([FromForm] Model.Product.Product updatedProduct, int id)
        {
            updatedProduct.Id = id;
            using (var client = new HttpClient())
            {
                var stringContent = new StringContent(JsonSerializer.Serialize(updatedProduct), Encoding.UTF8, "application/json");
                var postTask = client.PutAsync("https://localhost:5001/api/Product/" + id.ToString(), stringContent);
                postTask.Wait();
                var response = postTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(id.ToString(), "Product");
                }
            }
            return RedirectToAction(id.ToString() + "update", "Product");
        }
    }
}