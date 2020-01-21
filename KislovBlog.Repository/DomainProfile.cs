using AutoMapper;
using KislovBlog.Domain.DbEntity;
using KislovBlog.Domain.Models;

namespace KislovBlog.Repository
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<ArticleDto, Article>();
            CreateMap<Article, ArticleDto>();
        }
    }
}
