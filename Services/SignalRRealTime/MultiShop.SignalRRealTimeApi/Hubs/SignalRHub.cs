using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalRRealTimeApi.Services;

namespace MultiShop.SignalRRealTimeApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ISignalRService _signalRService;
        public SignalRHub(ISignalRService signalRService)
        {
            _signalRService = signalRService;
        }

        public async Task SendMessageAsync(string message)
        {
            var getTotalMessageCount = await _signalRService.GetTotalMessageCountByReceiverId(Context.ConnectionId);
            await Clients.All.SendAsync("receiveMessage", message);
        }
    }
}
