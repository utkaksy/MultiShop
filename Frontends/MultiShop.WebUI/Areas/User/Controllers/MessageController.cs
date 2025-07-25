﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.MessageService;
using MultiShop.WebUI.Services.UserServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;

        public MessageController(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        public async Task<IActionResult> Inbox()
        {
            var user = await _userService.GetUserInfo();
            var values = await _messageService.GetInboxMessagesAsync(user.Id);
            return View(values);
        }

        public async Task<IActionResult> Sendbox()
        {
            var user = await _userService.GetUserInfo();
            var values = await _messageService.GetSendboxMessagesAsync(user.Id);
            return View(values);
        }
    }
}
