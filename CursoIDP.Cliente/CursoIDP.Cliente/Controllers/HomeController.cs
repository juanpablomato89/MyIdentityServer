using CursoIDP.Cliente.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CursoIDP.Cliente.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _ClientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory ClientFactory)
        {
            _logger = logger;
            _ClientFactory = ClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<ActionResult> Usuario()
        {
            var httpClient = _ClientFactory.CreateClient("ApiClient");
            var response = await httpClient.GetAsync("api/usuario").ConfigureAwait(false);

            response.EnsureSuccessStatusCode();


            var companiesString = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<UsuarioModel>>(companiesString, 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return View(users);
        }

    }
}
