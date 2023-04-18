namespace AirsoftClub.Domain.Core.Models.InfoPost
{
    public abstract class BaseInfoPost<T>
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string? Photo { get; set; }
        public DateTime CreationDt { get; set; }

        public Guid AuthorId { get; set; }
        public T Author { get; set; }
    }
}
