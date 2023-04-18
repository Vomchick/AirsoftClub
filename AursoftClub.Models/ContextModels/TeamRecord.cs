namespace AirsoftClub.Models.ContextModels
{
    public class TeamRecord
    {
        public Guid Id { get; set; }
        public int PeopleCount { get; set; }

        public Game Game { get; set; }
        public Team Team { get; set; }
    }
}
