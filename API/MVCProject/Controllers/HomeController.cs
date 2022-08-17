using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCProject.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
        public async Task<IActionResult> CategoryAll()
        {
            CategoryAll categoryAlls;
            using (HttpClient client = new HttpClient())
            {
                string baseUrl = "https://localhost:44369/api/category";
                var response = await client.GetAsync(baseUrl);
                var result = await response.Content.ReadAsStringAsync();
                categoryAlls = JsonConvert.DeserializeObject<CategoryAll>(result);

            }

            return View(categoryAlls);
        }
        public async Task<IActionResult> ProductCreate()
        {
            using(HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert
                    .SerializeObject(new {Name="Samsung", Price =45, 
                        DiscountPrice=5, IsActive=true, CategoryId=1}), Encoding.UTF8, "application/json");
                string endpoint = "https://localhost:44369/api/product";
                var response = await client.PostAsync(endpoint, content);
            }
            return Ok("yaradildi");
        }
        public IActionResult ProductAll()
        {
            return View();
        }
    }
}
