using System.Collections.Generic;
using Tamagotchi.Common.Enums;

namespace Tamagotchi.Common.Models
{
    public class PetModel : BaseMnModel
    {
        public string Nickname { get; set; }

        public UserModel Owner { get; set; }
        public AnimalModel Animal { get; set; }

        public Gender Gender { get; set; }
        public LogModel[] Logs { get; set; }
        public Dictionary<string, double> CurrentGamePoints { get; set; }
    }
}
