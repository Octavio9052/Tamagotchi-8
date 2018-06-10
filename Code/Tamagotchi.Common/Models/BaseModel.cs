using System;

namespace Tamagotchi.Common.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
    }
}
