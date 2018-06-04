using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamagotchi.Common.Models;

namespace Tamagotchi.Common.Messages
{
    class MessageRequest<T> where T : BaseModel
    {
        public Guid UserToken { get; set; }
        public IEnumerable<T> Body { get; set; }
        public Byte[] File { get; set; }
    }
}
