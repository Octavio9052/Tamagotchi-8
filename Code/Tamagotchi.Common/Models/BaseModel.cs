using System;

namespace Tamagotchi.Common.Models
{
    public class BaseModel
    {
        public string Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
    }
}
