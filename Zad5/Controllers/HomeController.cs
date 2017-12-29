using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Zad5.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Zad5()
        {
            return View();
        }

        public async Task<object> GetTags()
        {
            using (HttpClient client = new HttpClient())
            {
                var result = await client.GetStringAsync("https://api.tronalddump.io/tags");
                JObject parsedResult = JObject.Parse(result);
                var tags = parsedResult.GetValue("_embedded").Children();
                return tags;
            }
        }

        public async Task<object> GetQuotes(string param)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = await client.GetStringAsync("https://api.tronalddump.io/search/quote?query=" + param);
                JObject parsedResult = JObject.Parse(result);
                var quotes = parsedResult.GetValue("_embedded");
                var bla = parsedResult.GetValue("_embedded").Children();
                var blla = parsedResult.SelectTokens("quotes");
                return quotes;
            }

        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
