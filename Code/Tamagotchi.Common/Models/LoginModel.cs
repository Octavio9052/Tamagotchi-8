using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tamagotchi.Common.Models
{
    public class LoginModel : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
