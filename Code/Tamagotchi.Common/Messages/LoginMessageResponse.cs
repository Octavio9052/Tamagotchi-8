using System;
using System.Collections.Generic;
using Tamagotchi.Common.Models;

namespace Tamagotchi.Common.Messages
{
    public class LoginMessageResponse
    {
        public UserModel User { get; set; }
        public Guid UserToken { get; set; }
        public string Error { get; set; }
    }
}
