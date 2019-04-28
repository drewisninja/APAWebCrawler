using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebCrawler.Models
{
    public class PlayerStats : DbContext
    {
        public DbSet<Players> Players { get; set; }

        public Players tempPlayers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Players>()
                .HasKey(c => new { c.PlayerID, c.TeamID });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-KQQQB0A\SQLEXPRESS;Database=APA_OrangeCounty;Trusted_Connection=True;");
        }
    }

        public class Players {

        [Key]
        public int PlayerID { get; set; }
        [Key]
        public int TeamID { get; set; }

        public string PlayerName { get; set; }

    }

    //public string SkillLevel { get; set; }

    //public string MatchsWonPlayed { get; set; }

    //public string WinPercentage { get; set; }

    //public string PointPerMatch { get; set; }

    //public string PointsAgainst { get; set; }
}
