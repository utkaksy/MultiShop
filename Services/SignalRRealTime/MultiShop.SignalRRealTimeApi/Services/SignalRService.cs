
namespace MultiShop.SignalRRealTimeApi.Services
{
    public class SignalRService : ISignalRService
    {
        private readonly HttpClient _httpClient;

        public SignalRService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetTotalMessageCountByReceiverId(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"UserMessages/GetTotalMessageCountByReceiverId?id={id}");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
