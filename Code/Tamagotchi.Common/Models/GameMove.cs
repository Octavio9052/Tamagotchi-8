using Tamagotchi.Common.Enums;

namespace Tamagotchi.Common.Models
{
    public class GameMove
    {
        public string PetId { get; set; }
        public Action Action { get; set; }
    }
}