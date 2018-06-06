using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Core
{
    [Serializable]
    public class PetStatus
    {
        public string Nickname { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public Dictionary<string, double> GamePoints { get; set; }
    }
}
