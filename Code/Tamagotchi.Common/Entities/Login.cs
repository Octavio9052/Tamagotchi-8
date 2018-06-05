using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tamagotchi.Common.Entities
{
    public class Login : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }


        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
