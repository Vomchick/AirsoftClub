namespace AirsoftClub.Models.ContextModels
{
    public class Club
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Player> Players { get; set; }
        public List<Game> Games { get; set; }
        public List<FiringField> FiringFields { get; set; }
    }
}
