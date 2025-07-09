using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MultiShop.Message.Dtos;
using MultiShop.Message.Services;
using System.Threading.Tasks;

namespace MultiShop.Message.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessagesController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public UserMessagesController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessagesAsync()
        {
            var values = await _userMessageService.GetAllMessagesAsync();
            return Ok(values);
        }

        [HttpGet("GetMessageSendbox")]
        public async Task<IActionResult> GetSendboxMessagesAsync(string id)
        {
            var values = await _userMessageService.GetSendboxMessagesAsync(id);
            return Ok(values);
        }

        [HttpGet("GetMessageInbox")]
        public async Task<IActionResult> GetInboxMessagesAsync(string id)
        {
            var values = await _userMessageService.GetInboxMessagesAsync(id);
            return Ok(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdMessageAsync(int id)
        {
            var values = await _userMessageService.GetByIdMessageAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            await _userMessageService.CreateMessageAsync(createMessageDto);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMessageAsync(int id)
        {
            await _userMessageService.DeleteMessageAsync(id);
            return Ok("Başarılı");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            await _userMessageService.UpdateMessage(updateMessageDto);
            return Ok("Başarılı");
        }
    }
}
