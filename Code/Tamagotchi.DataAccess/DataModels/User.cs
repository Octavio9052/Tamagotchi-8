using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tamagotchi.DataAccess.DataModels
{
    public class User : BaseRelationalEntity
    {
        [Required]
        public string Name { get; set; }
        public string PhotoUri { get; set; }
        public Dictionary<int, string> Pets { get; set; }
        public Dictionary<int, string> Creations { get; set; }

        public ICollection<Animal> Animal { get; set; }
        public ICollection<Session> Session { get; set; }

        
        public virtual Login Login { get; set; }
        [Required]
        public string LoginId { get; set; }
    }
}
