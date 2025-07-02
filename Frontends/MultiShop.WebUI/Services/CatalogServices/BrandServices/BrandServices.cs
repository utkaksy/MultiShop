using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices
{
    public class BrandServices : IBrandServices
    {
        private readonly HttpClient _httpClient;
        public BrandServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            await _httpClient.PostAsJsonAsync<CreateBrandDto>("Brands", createBrandDto);
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _httpClient.DeleteAsync("Brands?id=" + id);
        }

        public async Task<List<ResultBrandDto>> GetAllBrandAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Brands");
            // Başarısız ise detaylı log
            if (!responseMessage.IsSuccessStatusCode)
            {
                string error = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine($"[HTTP ERROR] StatusCode: {responseMessage.StatusCode}, Content: {error}");
                return new List<ResultBrandDto>(); // veya null
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
            return values ?? new List<ResultBrandDto>();
        }

        public async Task<UpdateBrandDto> GetByIdBrandAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("Brands/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateBrandDto>();
            return values;
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateBrandDto>("Brands", updateBrandDto);
        }
    }
}
