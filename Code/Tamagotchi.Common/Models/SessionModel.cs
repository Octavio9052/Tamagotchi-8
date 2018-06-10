using System;

namespace Tamagotchi.Common.Models
{
    public class SessionModel : BaseModel
    {
        public Guid Guid { get; set; }
        public int UserId { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
