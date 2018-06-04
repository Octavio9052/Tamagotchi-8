using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Tamagotchi.Common.Models;

namespace Tamagotchi.Common.Messages
{
    class MessageResponse<T> where T : BaseModel
    {
        public IEnumerable<T> Body;
        public IEnumerable<string> Errors;
        public IEnumerable<Stream> Files;
    }
}
