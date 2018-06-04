using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamagotchi.Common.Models;

namespace Tamagotchi.Common.Messages
{
    public class LoginMessageResponse
    {
        public UserModel User { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
