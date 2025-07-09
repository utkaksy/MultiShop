using MultiShop.DtoLayer.MessageDtos;
using MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.MessageService
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessagesAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"usermessages/GetMessageInbox/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultInboxMessageDto>>(jsonData);
            return values;

        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessagesAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"usermessages/GetMessageSendbox/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSendboxMessageDto>>(jsonData);
            return values;
        }
    }
}
