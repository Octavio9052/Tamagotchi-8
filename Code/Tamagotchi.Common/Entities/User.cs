﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tamagotchi.Common.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string PhotoUri { get; set; }
        public Dictionary<int, string> Pets { get; set; }
        public Dictionary<int, string> Creations { get; set; }

        public ICollection<Animal> Animal { get; set; }
        public ICollection<Session> Session { get; set; }
        public virtual Login Login { get; set; }
    }
}
