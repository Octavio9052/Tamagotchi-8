﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tamagotchi.Common.Entities
{
    class Login : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
    }
}
