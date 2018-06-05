using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tamagotchi.Common.Entities
{
    [NotMapped]
    public class Log : BaseEntity
    {
        [NotMapped]
        public string Message { get; set; }
    }
}
