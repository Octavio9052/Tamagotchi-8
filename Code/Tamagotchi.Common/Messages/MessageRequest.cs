﻿using System;
using System.Collections.Generic;
using Tamagotchi.Common.Models;

namespace Tamagotchi.Common.Messages
{
    public class MessageRequest<T> where T : BaseModel
    {
        public Guid UserToken { get; set; }
        public T Body { get; set; }
        public Byte[] File { get; set; }
    }
}
