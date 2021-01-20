using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ArmyRosterAPI.Models;

namespace ArmyRosterAPI.AccessDataBases
{
    public class ArmyRosterContext : DbContext
    {
        public ArmyRosterContext(DbContextOptions<ArmyRosterContext> options)
            : base(options)
        {

        }

        public DbSet<Roster> Rosters { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Roster)
                .WithOne(r => r.User)
                .HasForeignKey<Roster>(u => u.UserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Roster>().HasData(new Roster { Id = 1, ArmyName = "Strongers Army Ever", UserId = 1 });
            //modelBuilder.Entity<User>().HasData(new User{Id = 1, FirstName = "Bartosz", SecondName = "Bednarek", Email = "email", City = "Poznan" });

        }
    }
}
