using KislovBlog.Domain.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace KislovBlog.Controllers.Controllers
{
    [Controller]
    [Route("Articles")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageWorker _messageWorker;
        public MessageController(IMessageWorker messageWorker)
        {
            _messageWorker = messageWorker;
        }



    }
}
