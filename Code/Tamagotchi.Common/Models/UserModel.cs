using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tamagotchi.Common.Models
{
    public class UserModel : BaseModel
    {
        [Required]
        public string Name { get; set; }
        public string PhotoUri { get; set; }
        public Dictionary<string, string> Pets { get; set; }
        public Dictionary<int, string> Creations { get; set; }
        public SessionModel Session { get; set; }
    }
}
