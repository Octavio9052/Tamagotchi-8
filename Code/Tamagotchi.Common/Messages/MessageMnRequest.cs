using System;
using System.Collections.Generic;
using Tamagotchi.Common.Models;

namespace Tamagotchi.Common.Messages
{
    public class MessageMnRequest<T> where T : BaseMnModel
    {
        public Guid UserToken { get; set; }
        public IEnumerable<T> Body { get; set; }
        public Byte[] File { get; set; }
    }
}
