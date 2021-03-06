﻿using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using Tamagotchi.Common.Enums;

namespace Tamagotchi.DataAccess.DataModels
{
    public class Pet : BaseDocument
    {
        [BsonElement("nickname")]
        [BsonRequired]
        public string Nickname { get; set; }

        [BsonElement("ownerId")]
        [BsonRequired]
        public string OwnerId { get; set; }

        [BsonElement("animalId")]
        [BsonRequired]
        public string AnimalId { get; set; }

        [BsonElement("gender")] public Gender Gender { get; set; }
        [BsonElement("logs")] public Log[] Logs { get; set; }

        [BsonElement("eatPoints")]
        [BsonRequired]
        public int EatPoints { get; set; }

        [BsonElement("playPoints")]
        [BsonRequired]
        public int PlayPoints { get; set; }

        [BsonElement("sleepPoints")]
        [BsonRequired]
        public int SleepPoints { get; set; }
    }
}