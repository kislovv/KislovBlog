using KislovBlog.Domain.DbEntity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KislovBlog.Repository
{
    public class ArticleRepository
    {
        public List<Article> Articles { get; set; } = new List<Article>();

        public List<Article> GetAllArticles() => Articles;

        public IEnumerable<string> GetAllTitles() => Articles.Select(x => x.Title);

        public void AddArticle(Article article) => Articles.Add(article);

        public void EditArticle(Article article)
        {
            var index = Articles.IndexOf(article);
            if (index == -1)
            {
                throw new ApplicationException("Не найдено статьи с таким заголовком");
            } 
            Articles[index] = article;
        }
    }
}
