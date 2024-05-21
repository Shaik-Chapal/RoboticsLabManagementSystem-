using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoboticsLabManagementSystem.Domain.Entities;
using RoboticsLabManagementSystem.Infrastructure;

namespace RoboticsLabManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/Messages/send
        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] MessageCreateDto messageDto)
        {
            if (messageDto == null || string.IsNullOrWhiteSpace(messageDto.Content))
            {
                return BadRequest("Invalid message content.");
            }

            var message = new Message
            {
                Id = Guid.NewGuid(),
                SenderId = messageDto.SenderId,
                ReceiverId = messageDto.ReceiverId,
                Content = messageDto.Content,
                SentAt = DateTime.UtcNow
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return Ok(message);
        }

        // GET: api/Messages/received/{receiverId}
        [HttpGet("received/{receiverId}")]
        public async Task<IActionResult> GetReceivedMessages(Guid receiverId)
        {
            var messages = await _context.Messages
                .Where(m => m.ReceiverId == receiverId)
                .Include(m => m.Sender)
                .ToListAsync();

            if (messages == null || messages.Count == 0)
            {
                return NotFound("No messages found for the specified receiver.");
            }

            return Ok(messages);
        }

        // GET: api/Messages/sent/{senderId}
        [HttpGet("sent/{senderId}")]
        public async Task<IActionResult> GetSentMessages(Guid senderId)
        {
            var messages = await _context.Messages
                .Where(m => m.SenderId == senderId)
                .Include(m => m.Receiver)
                .ToListAsync();

            if (messages == null || messages.Count == 0)
            {
                return NotFound("No messages found for the specified sender.");
            }

            return Ok(messages);
        }
    }
}