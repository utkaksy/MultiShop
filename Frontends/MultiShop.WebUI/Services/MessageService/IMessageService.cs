using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Services.MessageService
{
    public interface IMessageService
    {
        Task<List<ResultInboxMessageDto>> GetInboxMessagesAsync(string id);
        Task<List<ResultSendboxMessageDto>> GetSendboxMessagesAsync(string id);
        //Task<List<ResultMessageDto>> GetAllMessagesAsync();
        //Task<GetByIdMessageDto> GetByIdMessageAsync(int id);
        //Task CreateMessageAsync(CreateMessageDto createMessageDto);
        //Task DeleteMessageAsync(int id);
        //Task UpdateMessage(UpdateMessageDto updateMessageDto);
    }
}
