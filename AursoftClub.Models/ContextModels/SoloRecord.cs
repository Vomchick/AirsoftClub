using AirsoftClub.Models.Enums;

namespace AirsoftClub.Models.ContextModels
{
    public class SoloRecord
    {
        public Guid Id { get; set; }
        public bool NeedARent { get; set; }
        public PickUp PickUp { get; set; }

        public Game Game { get; set; }
        public Player Player { get; set; }
    }
}
