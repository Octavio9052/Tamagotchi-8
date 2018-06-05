using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Tamagotchi.Common.Entities
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
