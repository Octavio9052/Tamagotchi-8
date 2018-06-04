using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tamagotchi.Common.Models
{
    public class UserModel : BaseModel
    {
        public string Name { get; set; }
        public string PhotoUri { get; set; }
        public Dictionary<int, string> Pets { get; set; }
        public Dictionary<int, string> Creations { get; set; }
        public string Session { get; set; }
    }
}
