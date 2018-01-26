﻿// <auto-generated />
using BoardGames.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BoardGames.Migrations
{
    [DbContext(typeof(BoardGamesContext))]
    [Migration("20180126100636_Dev3")]
    partial class Dev3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BoardGames.Models.BoardGameGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BoardGameListsId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("BoardGameListsId")
                        .IsUnique()
                        .HasFilter("[BoardGameListsId] IS NOT NULL");

                    b.ToTable("BoardGameGenre");
                });

            modelBuilder.Entity("BoardGames.Models.BoardGamesList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Available");

                    b.Property<bool>("IsAvailable");

                    b.Property<int?>("ManufacturerId");

                    b.Property<decimal>("Price");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("BoardGamesList");
                });

            modelBuilder.Entity("BoardGames.Models.Manufacturers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("BoardGames.Models.BoardGameGenre", b =>
                {
                    b.HasOne("BoardGames.Models.BoardGamesList", "BoardGameLists")
                        .WithOne("Genre")
                        .HasForeignKey("BoardGames.Models.BoardGameGenre", "BoardGameListsId");
                });

            modelBuilder.Entity("BoardGames.Models.BoardGamesList", b =>
                {
                    b.HasOne("BoardGames.Models.Manufacturers", "Manufacturer")
                        .WithMany("BoardGameLists")
                        .HasForeignKey("ManufacturerId");
                });
#pragma warning restore 612, 618
        }
    }
}