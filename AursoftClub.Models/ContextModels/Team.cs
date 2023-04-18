namespace AirsoftClub.Models.ContextModels
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Player> Players { get; set; }
        public List<TeamRecord> TeamRecords { get; set; }
    }
}
