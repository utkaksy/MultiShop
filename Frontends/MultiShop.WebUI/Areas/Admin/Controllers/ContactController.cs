using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/Contact")]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İletişimlar";
            ViewBag.v3 = "İletişim Listesi";
            ViewBag.v0 = "İletişim İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44343/api/Contacts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("CreateContact")]
        [HttpGet]
        public IActionResult CreateContact()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İletişimlar";
            ViewBag.v3 = "Yeni İletişim Girişi";
            ViewBag.v0 = "İletişim İşlemleri";
            return View();
        }

        [Route("CreateContact")]
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44343/api/Contacts", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Contact", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteContact/{id}")]
        public async Task<IActionResult> DeleteContact(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:44343/api/Contacts?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Contact", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateContact/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateContact(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İletişimlar";
            ViewBag.v3 = "İletişim Güncelleme Sayfası";
            ViewBag.v0 = "İletişim İşlemleri";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44343/api/Contacts/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateContactDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("UpdateContact/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44343/api/Contacts/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Contact", new { area = "Admin" });
            }
            return View();
        }
    }
}
