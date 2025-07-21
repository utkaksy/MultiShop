namespace MultiShop.SignalRRealTimeApi.Services
{
    public interface ISignalRService
    {
        Task<int> GetTotalMessageCountByReceiverId(string id);
    }
}
