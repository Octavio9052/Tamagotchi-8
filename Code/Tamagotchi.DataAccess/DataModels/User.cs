using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tamagotchi.DataAccess.DataModels
{
    public class User : BaseRelationalEntity
    {
        [Required]
        public string Name { get; set; }
        public string PhotoUri { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}
