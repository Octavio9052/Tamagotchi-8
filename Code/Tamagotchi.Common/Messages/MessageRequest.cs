using System;

namespace Tamagotchi.Common.Messages
{
    public class MessageRequest<T>
    {
        public Guid UserToken { get; set; }
        public T Body { get; set; }
    }
}
