using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestInnom.MVC.Models;

namespace TestInnom.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var client = new RestClient();
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            client.Authenticator = new JwtAuthenticator(accessToken);
            var url = _configuration.GetSection("APIBaseUrl").Value + "Product/GetAll"; // null
            var request = new RestRequest(url, DataFormat.Json);
            var Products = await client.GetAsync<List<Product>>(request);
            return View(Products.AsQueryable());
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Claims()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return new SignOutResult(new[] { "Cookies", "oidc" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
