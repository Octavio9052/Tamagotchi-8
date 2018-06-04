using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamagotchi.Common.Models;

namespace Tamagotchi.Common.Messages
{
    public class LoginMessageRequest
    {
        public UserModel Login { get; set; }
    }
}
