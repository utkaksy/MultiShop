using Microsoft.AspNetCore.Mvc;
using MultiShop.RapidApiUI.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MultiShop.RapidApiUI.Controllers
{
    public class DefaultController : Controller
    {
        public async Task<IActionResult> WeatherDetail()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://the-weather-api.p.rapidapi.com/api/weather/ankara"),
                Headers =
    {
        { "x-rapidapi-key", "3e8640279dmsh3beaf3c0b2e9734p1f6c2ajsn2791be2bdf3c" },
        { "x-rapidapi-host", "the-weather-api.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var weather = JsonConvert.DeserializeObject<WeatherViewModel.Rootobject>(body);

                ViewBag.temp = weather.Data.Temp;
            }
            return View();
        }
    }
}
