using System.Collections.Generic;

namespace Tamagotchi.Common.Models
{
    public class UserModel : BaseModel
    {
        public string Name { get; set; }
        public string PhotoUri { get; set; }
        public Dictionary<string, string> Pets { get; set; }
        public Dictionary<int, string> Creations { get; set; }
        public SessionModel Session { get; set; }
    }
}
