namespace AursoftClub.Models.ContextModels.InfoPost
{
    public abstract class BaseInfoPost
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string? Photo { get; set; }
        public DateTime CreationDt { get; set; }

        public Guid AuthorId { get; set; }
    }
}
