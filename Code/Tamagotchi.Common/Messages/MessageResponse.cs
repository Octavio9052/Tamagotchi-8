using System.Collections.Generic;
using System.IO;
using Tamagotchi.Common.Models;

namespace Tamagotchi.Common.Messages
{
    public class MessageResponse<T> where T : BaseModel
    {
        public T Body { get; set; }
        public string Error { get; set; }
        public IEnumerable<Stream> Files { get; set; }
    }
}
