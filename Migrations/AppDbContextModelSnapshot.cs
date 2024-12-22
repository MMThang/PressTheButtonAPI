﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PressTheButtonAPI.Data;

#nullable disable

namespace PressTheButtonAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PressTheButtonAPI.Entities.FavoriteScenarioUser", b =>
                {
                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("scenarioId")
                        .HasColumnType("int");

                    b.HasKey("userId", "scenarioId");

                    b.HasIndex("scenarioId");

                    b.ToTable("FavoriteScenarioUsers");
                });

            modelBuilder.Entity("PressTheButtonAPI.Entities.HistoryScenarioUser", b =>
                {
                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("scenarioId")
                        .HasColumnType("int");

                    b.HasKey("userId", "scenarioId");

                    b.HasIndex("scenarioId");

                    b.ToTable("HistoryScenarioUsers");
                });

            modelBuilder.Entity("PressTheButtonAPI.Entities.Scenario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BadOutcome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeniedCount")
                        .HasColumnType("int");

                    b.Property<string>("GoodOutcome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PostDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PressedCount")
                        .HasColumnType("int");

                    b.Property<Guid>("ScenarioOwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ScenarioOwnerId");

                    b.ToTable("Scenarios");
                });

            modelBuilder.Entity("PressTheButtonAPI.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PressTheButtonAPI.Entities.FavoriteScenarioUser", b =>
                {
                    b.HasOne("PressTheButtonAPI.Entities.Scenario", "scenario")
                        .WithMany("FavoriteUsers")
                        .HasForeignKey("scenarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_FavoriteScenarioUser_ScenarioId");

                    b.HasOne("PressTheButtonAPI.Entities.User", "user")
                        .WithMany("Favorites")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_FavoriteScenarioUser_UserId");

                    b.Navigation("scenario");

                    b.Navigation("user");
                });

            modelBuilder.Entity("PressTheButtonAPI.Entities.HistoryScenarioUser", b =>
                {
                    b.HasOne("PressTheButtonAPI.Entities.Scenario", "scenario")
                        .WithMany("HistoryUsers")
                        .HasForeignKey("scenarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_HistoryScenarioUser_ScenarioId");

                    b.HasOne("PressTheButtonAPI.Entities.User", "user")
                        .WithMany("History")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_HistoryScenarioUser_UserId");

                    b.Navigation("scenario");

                    b.Navigation("user");
                });

            modelBuilder.Entity("PressTheButtonAPI.Entities.Scenario", b =>
                {
                    b.HasOne("PressTheButtonAPI.Entities.User", "ScenarioOwner")
                        .WithMany("MyScenarios")
                        .HasForeignKey("ScenarioOwnerId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("ScenarioOwner");
                });

            modelBuilder.Entity("PressTheButtonAPI.Entities.Scenario", b =>
                {
                    b.Navigation("FavoriteUsers");

                    b.Navigation("HistoryUsers");
                });

            modelBuilder.Entity("PressTheButtonAPI.Entities.User", b =>
                {
                    b.Navigation("Favorites");

                    b.Navigation("History");

                    b.Navigation("MyScenarios");
                });
#pragma warning restore 612, 618
        }
    }
}
