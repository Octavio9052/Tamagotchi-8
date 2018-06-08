using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Tamagotchi.Common.Models;

namespace Tamagotchi.Common.Messages
{
    public class MessageMnResponse<T> where T : BaseMnModel
    {
        public IEnumerable<T> Body;
        public IEnumerable<string> Errors;
        public IEnumerable<Stream> Files;
    }
}
