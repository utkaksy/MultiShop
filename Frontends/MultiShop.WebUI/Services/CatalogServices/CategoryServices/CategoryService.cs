using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCategoryDto>("categories", createCategoryDto);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _httpClient.DeleteAsync("categories?id=" + id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            //var responseMessage = await _httpClient.GetAsync("categories");
            //var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            //return values;

            //-----------------------------------------------

            var responseMessage = await _httpClient.GetAsync("categories");
            // Başarısız ise detaylı log
            if (!responseMessage.IsSuccessStatusCode)
            {
                string error = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine($"[HTTP ERROR] StatusCode: {responseMessage.StatusCode}, Content: {error}");
                return new List<ResultCategoryDto>(); // veya null
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            return values ?? new List<ResultCategoryDto>();
        }

        public async Task<UpdateCategoryDto> GetByIdCategoryAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("categories/"+id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateCategoryDto>();
            return values;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCategoryDto>("categories", updateCategoryDto);
        }
    }
}
