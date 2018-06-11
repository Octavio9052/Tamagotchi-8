using System;
using System.Collections.Generic;
using Tamagotchi.Common.Models;

namespace Tamagotchi.Common.Messages
{
    public class MessageRequest<T>
    {
        public Guid UserToken { get; set; }
        public T Body { get; set; }
    }
}
