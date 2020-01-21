using System.Threading.Tasks;
using KislovBlog.Domain.Helpers;
using KislovBlog.Domain.Models;

namespace KislovBlog.Domain.Abstraction
{
    public interface IMessageWorker
    {
        Task<string> AnalysMessage(string message);
        Task<Result> AddNewArticle(ArticleDto articleDto);
    }
}
