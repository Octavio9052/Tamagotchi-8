using System.ComponentModel.DataAnnotations;

namespace Tamagotchi.Common.Models
{
    public class LoginModel : BaseModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string UserId { get; set; }
        public virtual UserModel User { get; set; }
    }
}
