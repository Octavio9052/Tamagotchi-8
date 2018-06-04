using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tamagotchi.Common.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
    }
}
