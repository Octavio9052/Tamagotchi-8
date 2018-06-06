using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tamagotchi.Common.DataModels
{
    public class Animal : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string IdleUri { get; set; }
        public string PlayUri { get; set; }
        public string EatUri { get; set; }
        public string SleepUri { get; set; }
        public int TimesDownloaded { get; set; }
        public Dictionary<string, double> MaxGamePoints { get; set; }
        public string PacketUri { get; set; }
        public bool IsReady { get; set; }
        public bool IsActive { get; set; }

        public int CreatorId { get; set; }
        public User User { get; set; }
    }
}
