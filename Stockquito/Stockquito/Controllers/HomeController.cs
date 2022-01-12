using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Stockquito.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Stockquito.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory httpClientFactory;


        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://financialmodelingprep.com/api/v3/etf/list?apikey=2c6c41fb4370c3fe4e7cb101618b1692");

            request.Headers.Add("Upgrade-Insecure-Requests", "1");

            var client = httpClientFactory.CreateClient();

            var response = await client.SendAsync(request);
            
            var model = new StocksModel();

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var etfs = JsonConvert.DeserializeObject<List<ETF>>(result);
                model.EtfList = etfs;
            }
            else
            {
                //GetBranchesError = true;
                //Branches = Array.Empty<GitHubBranch>();
            }




            return View(model);
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
    }
}
