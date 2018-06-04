using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamagotchi.Common.Enums;

namespace Tamagotchi.Common.Entities
{
    public class Pet : BaseEntity
    {
        public string Nickname { get; set; }
        public int OwnerId { get; set; }
        public int AnimalId { get; set; }
        public Gender Gender { get; set; }
        public Log[] Logs { get; set; }
        public Dictionary<string, double> CurrentGamePoints { get; set; }
    }
}
