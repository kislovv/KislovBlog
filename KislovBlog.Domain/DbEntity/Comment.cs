using System;
using System.Collections.Generic;
using System.Text;

namespace KislovBlog.Domain.DbEntity
{
    public class Comment
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public long ArticleId { get; set; }
        public long UserId { get; set; }
        public long Likes { get; set; }
    }
}
