using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tamagotchi.Common.Models
{
    public class AnimalModel : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public int TimesDownloaded { get; set; }
        public bool IsReady { get; set; }
        public bool IsActive { get; set; }

        [Required]
        public string IdleUri { get; set; }
        [Required]
        public string PlayUri { get; set; }
        [Required]
        public string EatUri { get; set; }
        [Required]
        public string SleepUri { get; set; }
        [Required]
        public string PacketUri { get; set; }
        
        [Required]
        public string PacketFile { get; set; }
        [Required]
        public string PlayImage { get; set; }
        [Required]
        public string EatImage { get; set; }
        [Required]
        public string SleepImage { get; set; }
        [Required]
        public string IdleImage { get; set; }

        public UserModel User { get; set; }
        public IEnumerable<LogModel> Logs { get; set; }
    }
}