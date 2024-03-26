using GameBib.Models;
using GameBibApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace GameBibApi.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Go to the App.config.example file and then follow Instructions

            optionsBuilder.UseMySql(
                System.Configuration.ConfigurationManager.ConnectionStrings["GameBibApi"].ConnectionString,
                ServerVersion.Parse("5.7.33-winx64"));

            //var steam = System.Configuration.ConfigurationManager.AppSettings["steamKey"];
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<WantedGame>()
           .HasKey(wg => wg.Id);

            modelBuilder.Entity<WantedGame>()
              .HasOne(wg => wg.app)
               .WithMany(g => g.WantedByUsers)
               .HasForeignKey(fg => fg.GameId);

            modelBuilder.Entity<WantedGame>()
                  .HasOne(wg => wg.userDto)
                  .WithMany(u => u.WantedGames)
                  .HasForeignKey(wg => wg.UserId);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "Dani", statusId = 0, Password = SecureHasher.Hash("1234")},
                new User { Id = 2, Username = "Justin", statusId = 0, Password = SecureHasher.Hash("1234")});
        }
    }
}
