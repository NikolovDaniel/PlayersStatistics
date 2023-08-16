﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlayersStatistics.Infrastructure.Data;

#nullable disable

namespace PlayersStatistics.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230524060723_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MatchPlayer", b =>
                {
                    b.Property<Guid>("MatchesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MatchesId", "PlayersId");

                    b.HasIndex("PlayersId");

                    b.ToTable("MatchPlayer");
                });

            modelBuilder.Entity("PlayersStatistics.Infrastructure.Models.Match", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Identificator for the entity.");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasComment("Date of when the match has been played.");

                    b.Property<int>("Duration")
                        .HasColumnType("int")
                        .HasComment("Duration of the match.");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasComment("Flag to delete the entity.");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Location where the match has been played.");

                    b.Property<int>("PlayerOneSets")
                        .HasColumnType("int")
                        .HasComment("Sets won by player one.");

                    b.Property<int>("PlayerTwoSets")
                        .HasColumnType("int")
                        .HasComment("Sets won by player two.");

                    b.Property<string>("Winner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Name of the winner of the match.");

                    b.HasKey("Id");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("PlayersStatistics.Infrastructure.Models.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Identificator for the entity.");

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .HasComment("Age of the player.");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasComment("Flag to delete the entity.");

                    b.Property<int>("Loses")
                        .HasColumnType("int")
                        .HasComment("The player's loses.");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Name of the player.");

                    b.Property<int>("Winrate")
                        .HasColumnType("int")
                        .HasComment("The player's total winrate.");

                    b.Property<int>("Wins")
                        .HasColumnType("int")
                        .HasComment("The player's wins.");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("MatchPlayer", b =>
                {
                    b.HasOne("PlayersStatistics.Infrastructure.Models.Match", null)
                        .WithMany()
                        .HasForeignKey("MatchesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlayersStatistics.Infrastructure.Models.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}