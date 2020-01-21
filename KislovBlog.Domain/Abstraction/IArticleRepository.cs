using System.Collections.Generic;
using KislovBlog.Domain.Models;

namespace KislovBlog.Domain.Abstraction
{
    public interface IArticleRepository
    {
        List<ArticleDto> GetAllArticles();
        IEnumerable<string> GetAllTitles();
        void AddArticle(ArticleDto article);
        void EditArticle(ArticleDto article);
    }
}
