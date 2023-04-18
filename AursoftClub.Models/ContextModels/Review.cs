namespace AirsoftClub.Models.ContextModels
{
    public class Review
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string? Photo { get; set; }
        public DateTime CreationDt { get; set; }
        public int Rating { get; set; }

        public Player Player { get; set; }
        public FiringField FiringField { get; set; }
    }
}
