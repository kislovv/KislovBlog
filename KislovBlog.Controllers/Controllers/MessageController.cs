using System.Threading.Tasks;
using AutoMapper;
using KislovBlog.Contracts;
using KislovBlog.Domain.Abstraction;
using KislovBlog.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace KislovBlog.Controllers.Controllers
{
    [Route("Articles")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageWorker _messageWorker;
        private readonly IMapper _mapper;
        public MessageController(IMessageWorker messageWorker, IMapper mapper)
        {
            _messageWorker = messageWorker;
            _mapper = mapper;
        }

        [HttpPost("new")]
        public async Task<IActionResult> AddArticle([FromBody] Article article)
        {
            var result = await _messageWorker.AddNewArticle(_mapper.Map<ArticleDto>(article)).ConfigureAwait(false);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest("Не удалось добавить запись");
        }

    }
}
