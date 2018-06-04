using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tamagotchi.Common.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
    }
}
