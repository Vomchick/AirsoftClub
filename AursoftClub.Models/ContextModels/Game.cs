using AirsoftClub.Models.Enums;

namespace AirsoftClub.Models.ContextModels
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string? Photo { get; set; }
        public DateTime CreationDt { get; set; }
        public int Price { get; set; }
        public DateOnly StartDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public GameType GameType { get; set; }

        public FiringField FiringField { get; set; }
        public Club Club { get; set; }
        public List<SoloRecord> SoloRecords { get; set; }
        public List<TeamRecord> TeamRecords { get; set; }
    }
}
