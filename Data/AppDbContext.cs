using Microsoft.EntityFrameworkCore;
using PressTheButtonAPI.Entities;

namespace PressTheButtonAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Scenario> Scenarios { get; set; }
        public DbSet<FavoriteScenarioUser> FavoriteScenarioUsers { get; set; }
        public DbSet<HistoryScenarioUser> HistoryScenarioUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Scenario>()
                .HasOne(o => o.ScenarioOwner)
                .WithMany(m => m.MyScenarios)
                .HasForeignKey(fk => fk.ScenarioOwnerId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            //Favorite
            modelBuilder.Entity<FavoriteScenarioUser>().HasKey(k => new { k.userId, k.scenarioId });

            modelBuilder.Entity<FavoriteScenarioUser>()
                .HasOne(bc => bc.user)
                .WithMany(m => m.Favorites)
                .HasForeignKey(fk => fk.userId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_FavoriteScenarioUser_UserId");
           
            modelBuilder.Entity<FavoriteScenarioUser>()
                .HasOne(bc => bc.scenario)
                .WithMany(m => m.FavoriteUsers)
                .HasForeignKey(fk => fk.scenarioId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_FavoriteScenarioUser_ScenarioId");

            //History
            modelBuilder.Entity<HistoryScenarioUser>()
                .HasKey(k => new { k.userId, k.scenarioId });

            modelBuilder.Entity<HistoryScenarioUser>()
                .HasOne(bc => bc.user)
                .WithMany(m => m.History)
                .HasForeignKey(fk => fk.userId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_HistoryScenarioUser_UserId");


            modelBuilder.Entity<HistoryScenarioUser>()
                .HasOne(bc => bc.scenario)
                .WithMany(m => m.HistoryUsers)
                .HasForeignKey(fk => fk.scenarioId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_HistoryScenarioUser_ScenarioId");
        }
    }
}
