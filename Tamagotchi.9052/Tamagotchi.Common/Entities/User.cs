using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tamagotchi.Common.Entities
{
    class User : BaseEntity
    {
        public string Name { get; set; }
        public string PhotoUri { get; set; }
        public Dictionary<int, string> Pets { get; set; }
        public Dictionary<int, string> Creations { get; set; }
    }
}
