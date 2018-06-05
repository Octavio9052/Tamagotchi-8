﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Tamagotchi.Common.Entities
{
    public class Login : BaseEntity
    {
        [Required]
        [StringLength(150)]
        [Index("Index_Email", IsUnique = true)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
