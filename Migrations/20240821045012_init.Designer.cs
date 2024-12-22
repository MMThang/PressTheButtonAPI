﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PressTheButtonAPI.Data;

#nullable disable

namespace PressTheButtonAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240821045012_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FavoriteUsersTable", b =>
                {
                    b.Property<Guid>("FavoriteUsersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FavoritesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FavoriteUsersId", "FavoritesId");

                    b.HasIndex("FavoritesId");

                    b.ToTable("FavoriteUsersTable");
                });

            modelBuilder.Entity("HistoryUsersTable", b =>
                {
                    b.Property<Guid>("HistoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HistoryUsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("HistoryId", "HistoryUsersId");

                    b.HasIndex("HistoryUsersId");

                    b.ToTable("HistoryUsersTable");
                });

            modelBuilder.Entity("PressTheButtonAPI.Entities.Scenario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BadOutcome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeniedCount")
                        .HasColumnType("int");

                    b.Property<string>("GoodOutcome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PressedCount")
                        .HasColumnType("int");

                    b.Property<Guid>("ScenarioOwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ScenarioOwnerId");

                    b.ToTable("scenarios");
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

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("FavoriteUsersTable", b =>
                {
                    b.HasOne("PressTheButtonAPI.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("FavoriteUsersId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("PressTheButtonAPI.Entities.Scenario", null)
                        .WithMany()
                        .HasForeignKey("FavoritesId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HistoryUsersTable", b =>
                {
                    b.HasOne("PressTheButtonAPI.Entities.Scenario", null)
                        .WithMany()
                        .HasForeignKey("HistoryId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("PressTheButtonAPI.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("HistoryUsersId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PressTheButtonAPI.Entities.Scenario", b =>
                {
                    b.HasOne("PressTheButtonAPI.Entities.User", "ScenarioOwner")
                        .WithMany("MyScenarios")
                        .HasForeignKey("ScenarioOwnerId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("ScenarioOwner");
                });

            modelBuilder.Entity("PressTheButtonAPI.Entities.User", b =>
                {
                    b.Navigation("MyScenarios");
                });
#pragma warning restore 612, 618
        }
    }
}