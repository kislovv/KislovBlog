namespace KislovBlog.Domain.DbEntity
{
    public class Article
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
    }
}
