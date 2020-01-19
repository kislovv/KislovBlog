using AutoMapper;
using KislovBlog.Domain.DbEntity;
using KislovBlog.Domain.Models;

namespace KislovBlog.Domain.MapperConfig
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<ArticleDto, Article>();
        }
    }
}
