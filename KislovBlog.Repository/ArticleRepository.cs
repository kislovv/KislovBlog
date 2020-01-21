using KislovBlog.Domain.DbEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using KislovBlog.Domain.Abstraction;
using KislovBlog.Domain.Models;

namespace KislovBlog.Repository
{

    public class ArticleRepository : IArticleRepository
    {
        private List<Article> Articles { get; set; } = new List<Article>();
        private readonly IMapper _mapper;

        public ArticleRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<ArticleDto> GetAllArticles() => _mapper.Map<List<ArticleDto>>(Articles);

        public IEnumerable<string> GetAllTitles() => Articles.Select(x => x.Title);

        public void AddArticle(ArticleDto article) => Articles.Add(_mapper.Map<Article>(article));

        public void EditArticle(ArticleDto article)
        {
            var artivcleEntity = _mapper.Map<Article>(article);
            var index = Articles.IndexOf(artivcleEntity);
            if (index == -1)
            {
                throw new ApplicationException("Не найдено статьи с таким заголовком");
            } 
            Articles[index] = artivcleEntity;
        }
    }
}
