using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tamagotchi.Common.Entities
{
    public class Session : BaseEntity
    {
        public Guid Guid { get; set; }
        public DateTime ExpirationDate { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }
    }
}
