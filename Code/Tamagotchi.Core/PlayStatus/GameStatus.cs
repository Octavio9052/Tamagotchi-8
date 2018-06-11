using System;

namespace Tamagotchi.Core.PlayStatus
{
    [Serializable]
    public class GameStatus
    {
        public bool Allowed { get; set; }
        public string Message { get; set; }
        public PetStatus PetStatus { get; set; }
    }
}
