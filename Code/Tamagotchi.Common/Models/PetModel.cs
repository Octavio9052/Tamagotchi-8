using System.Collections.Generic;
using Tamagotchi.Common.Enums;

namespace Tamagotchi.Common.Models
{
    public class PetModel : BaseModel
    {
        public string Nickname { get; set; }
        public UserModel Owner { get; set; }
        public AnimalModel Animal { get; set; }
        public Gender Gender { get; set; }
        public LogModel[] Logs { get; set; }
        public int EatPoints { get; set; }
        public int PlayPoints { get; set; }
        public int SleepPoints { get; set; }
    }
}