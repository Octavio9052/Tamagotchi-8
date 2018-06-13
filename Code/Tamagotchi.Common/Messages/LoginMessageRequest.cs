using System.ComponentModel.DataAnnotations;
using Tamagotchi.Common.Models;

namespace Tamagotchi.Common.Messages
{
    public class LoginMessageRequest
    {
        [Required]
        public LoginModel Login { get; set; }
        public string Name { get; set; }
    }
}
