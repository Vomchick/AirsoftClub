namespace AirsoftClub.Models.ContextModels
{
    public class FiringField
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string? Photo { get; set; }
        public DateTime CreationDt { get; set; }
        public bool IsCovered { get; set; }
        public string Address { get; set; }
        public decimal Rating { get; set; }

        public Club Club { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
