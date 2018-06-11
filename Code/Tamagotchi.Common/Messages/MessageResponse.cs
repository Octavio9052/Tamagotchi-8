using System.Collections.Generic;
using System.IO;
using Tamagotchi.Common.Models;

namespace Tamagotchi.Common.Messages
{
    public class MessageResponse<T> where T : BaseModel
    {
        public T Body;
        public IEnumerable<string> Errors;
        public IEnumerable<Stream> Files;
    }
}
