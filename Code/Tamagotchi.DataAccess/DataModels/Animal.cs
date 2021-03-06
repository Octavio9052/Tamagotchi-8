﻿using System;
using System.Collections.Generic;

namespace Tamagotchi.DataAccess.DataModels
{
    public class Animal : BaseRelationalEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string IdleUri { get; set; }
        public string PlayUri { get; set; }
        public string EatUri { get; set; }
        public string SleepUri { get; set; }
        public string PacketUri { get; set; }

        public int TimesDownloaded { get; set; }
        public bool IsReady { get; set; }
        public bool IsActive { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
