using System.Threading.Tasks;
using KislovBlog.Domain.Models;

namespace KislovBlog.Domain.Abstraction
{
    public interface IMessageWorker
    {
        Task<MessageDataDtoRs> AnalysMessage(MessageDataDto message);
    }
}
