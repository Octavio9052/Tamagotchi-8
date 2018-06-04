using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Tamagotchi.Common.Entities;

namespace Tamagotchi.DataAccess.Context
{
    class TamagotchiContext : DbContext
    {
        public TamagotchiContext() : base("name=Tamagotchi9052ConnString")
        {
            Database.SetInitializer<TamagotchiContext>(new DropCreateDatabaseAlways<TamagotchiContext>());
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
