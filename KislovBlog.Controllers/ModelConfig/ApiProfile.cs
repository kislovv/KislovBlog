using AutoMapper;
using KislovBlog.Contracts;
using KislovBlog.Domain.Models;

namespace KislovBlog.Controllers.ModelConfig
{
    public class ApiProfile :Profile
    {
        public ApiProfile()
        {
            CreateMap<Article, ArticleDto>();
            CreateMap<MessageDataDtoRs, MessageDataRs>();
        }
    }
}
