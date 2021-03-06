﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tamagotchi.DataAccess.DataModels
{
    public class Session : BaseRelationalEntity
    {
        [Required]
        [Index("Index_Guid", IsUnique = true)]
        public Guid Guid { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
