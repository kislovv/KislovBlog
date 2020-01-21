using System.Threading.Tasks;
using KislovBlog.Domain.Abstraction;
using KislovBlog.Domain.Helpers;
using KislovBlog.Domain.Models;

namespace KislovBlog.Domain.Services
{
    public class MessageWorker : IMessageWorker
    {
        private readonly ICensureChecker _censureChecker;
        private readonly IArticleRepository _articleRepository;
        public MessageWorker(ICensureChecker censureChecker, IArticleRepository articleRepository)
        {
            _censureChecker = censureChecker;
            _articleRepository = articleRepository;
        }

        public Task<string> AnalysMessage(string message)
        {
            var badWords = _censureChecker.CheckMessage(message.Split());
            foreach (var word in badWords)
            {
                message = message.Replace(word, _censureChecker.CensureWord(word));
            }
            return Task.FromResult(message);
        }

        public async Task<Result> AddNewArticle(ArticleDto articleDto)
        {
            var result = await AnalysMessage(articleDto.Text);
            articleDto.Text = result;
            _articleRepository.AddArticle(articleDto);
            return Result.Complete();
        }
    }
}
