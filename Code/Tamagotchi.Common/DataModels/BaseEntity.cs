using System;
using System.ComponentModel.DataAnnotations;

namespace Tamagotchi.Common.DataModels
{
    public class BaseEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public DateTime LastModified { get; set; }
    }
}
