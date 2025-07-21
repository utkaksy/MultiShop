using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public interface IUserMessageService
    {
        Task<List<ResultMessageDto>> GetAllMessagesAsync();
        Task<List<ResultInboxMessageDto>> GetInboxMessagesAsync(string id);
        Task<List<ResultSendboxMessageDto>> GetSendboxMessagesAsync(string id);
        Task<GetByIdMessageDto> GetByIdMessageAsync(int id);
        Task CreateMessageAsync(CreateMessageDto createMessageDto);
        Task DeleteMessageAsync(int id);
        Task UpdateMessage(UpdateMessageDto updateMessageDto);
        Task<int> GetTotalMessageCount();
        Task<int> GetTotalMessageCountByReceiverId(string id);
    }
}
