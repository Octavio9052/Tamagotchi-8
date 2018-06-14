using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tamagotchi.Common.Models
{
    public class UserModel : BaseModel
    {
        [Required]
        public string Name { get; set; }
        public string PhotoUri { get; set; }
        
        public List<PetModel> Pets { get; set; }
        public List<AnimalModel> Animals { get; set; }
    }
}
