namespace AirsoftClub.Models.ContextModels
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public Player Player { get; set; }
    }
}
