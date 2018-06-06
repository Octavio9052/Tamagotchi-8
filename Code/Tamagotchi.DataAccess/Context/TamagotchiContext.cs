using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Tamagotchi.Common.DataModels;

namespace Tamagotchi.DataAccess.Context
{
    class TamagotchiContext : DbContext
    {
        public TamagotchiContext() : base("name=Tamagotchi9052ConnString")
        {
            Database.SetInitializer<TamagotchiContext>(new DropCreateDatabaseIfModelChanges<TamagotchiContext>());
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Session> Sessions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasRequired(x => x.Login)
                .WithRequiredPrincipal(x => x.User);
            base.OnModelCreating(modelBuilder);
        }
    }
}
