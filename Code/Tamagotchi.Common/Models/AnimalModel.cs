using System.Collections.Generic;

namespace Tamagotchi.Common.Models
{
    public class AnimalModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int TimesDownloaded { get; set; }
        public bool IsReady { get; set; }
        public bool IsActive { get; set; }

        public string IdleUri { get; set; }
        public string PlayUri { get; set; }
        public string EatUri { get; set; }
        public string SleepUri { get; set; }
        public string PacketUri { get; set; }
        
        public string PacketFile { get; set; }
        public string PlayImage { get; set; }
        public string EatImage { get; set; }
        public string SleepImage { get; set; }
        public string IdleImage { get; set; }

        public UserModel User { get; set; }
        public IEnumerable<LogModel> Logs { get; set; }
    }
}