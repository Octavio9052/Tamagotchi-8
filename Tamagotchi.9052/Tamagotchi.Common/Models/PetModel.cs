using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamagotchi.Common.Enums;

namespace Tamagotchi.Common.Models
{
    public class PetModel : BaseModel
    {
        public string Nickname { get; set; }
        public int OwnerId { get; set; }
        public int AnimalId { get; set; }
        public Gender Gender { get; set; }
        public LogModel[] Logs { get; set; }
        public Dictionary<string, double> CurrentGamePoints { get; set; }
    }
}
