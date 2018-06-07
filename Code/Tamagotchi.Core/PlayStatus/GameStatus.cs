using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Core
{
    [Serializable]
    public class GameStatus
    {
        public bool Allowed { get; set; }
        public string Message { get; set; }
        public PetStatus PetStatus { get; set; }
    }
}
