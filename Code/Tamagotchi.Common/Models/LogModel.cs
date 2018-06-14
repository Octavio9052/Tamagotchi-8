namespace Tamagotchi.Common.Models
{
    public class LogModel : BaseModel
    {
        public string Message { get; set; }
        public string AnimalId { get; set; }
        public string AnimalName { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public string PetId { get; set; }
        public string PetName { get; set; }
    }
}
