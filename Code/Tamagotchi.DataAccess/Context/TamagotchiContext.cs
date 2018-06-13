﻿using System.Data.Entity;
using Tamagotchi.DataAccess.DataModels;

namespace Tamagotchi.DataAccess.Context
{
    public class TamagotchiContext : DbContext
    {
        public TamagotchiContext() : base("name=Tamagotchi9052ConnString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TamagotchiContext>());
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Session> Sessions { get; set; }

    }
}
