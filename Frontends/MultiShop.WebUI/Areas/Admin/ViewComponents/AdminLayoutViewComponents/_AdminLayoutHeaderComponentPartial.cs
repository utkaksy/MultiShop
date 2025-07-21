using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;
using MultiShop.WebUI.Services.UserServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutHeaderComponentPartial : ViewComponent
    {
        private readonly IMessageStatisticService _messageStatisticService;
        private readonly IUserService _userService;

        public _AdminLayoutHeaderComponentPartial(IMessageStatisticService messageStatisticService, IUserService userService)
        {
            _messageStatisticService = messageStatisticService;
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userInfo = await _userService.GetUserInfo();
            int messageCount = await _messageStatisticService.GetTotalMessageCountByReceiverId(userInfo.Id);
            ViewBag.MessageCount = messageCount;
            return View(messageCount);
        }
    }
}
