using System;
using System.Collections.Generic;
using System.Text;

namespace KislovBlog.Domain.DbEntity
{
    public class Article
    {
        public string Text { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
    }
}
