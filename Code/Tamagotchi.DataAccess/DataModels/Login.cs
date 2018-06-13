using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tamagotchi.DataAccess.DataModels
{
    public class Login : BaseRelationalEntity
    {
        [Required]
        [StringLength(150)]
        [Index("Index_Email", IsUnique = true)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
