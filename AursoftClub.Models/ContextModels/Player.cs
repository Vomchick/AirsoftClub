using AirsoftClub.Models.Enums;

namespace AirsoftClub.Models.ContextModels
{
    public class Player
    {
        public Guid Id { get; set; }
        public string CallSign { get; set; }
        public GameRole GameRole { get; set; }
        public string Description { get; set; }
        public TeamRole? TeamRole { get; set; }

        public User User { get; set; }
        public Team? Team { get; set; }
        public List<Club> Clubs { get; set; }
        public List<Review> Reviews { get; set; }
        public List<SoloRecord> SoloRecords { get; set; }
    }
}
