using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tamagotchi.Common.DataModels
{
    public class Session : BaseEntity
    {
        [Required]
        [Index("Index_Guid", IsUnique = true)]
        public Guid Guid { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
