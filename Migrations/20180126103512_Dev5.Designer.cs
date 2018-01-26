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
    [Migration("20180126103512_Dev5")]
    partial class Dev5
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

                    b.Property<string>("Name")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("BoardGameGenre");
                });

            modelBuilder.Entity("BoardGames.Models.BoardGamesList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Available");

                    b.Property<int?>("GenreId1");

                    b.Property<bool>("IsAvailable");

                    b.Property<int?>("ManufacturerId1");

                    b.Property<decimal>("Price");

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("GenreId1");

                    b.HasIndex("ManufacturerId1");

                    b.ToTable("BoardGamesList");
                });

            modelBuilder.Entity("BoardGames.Models.Manufacturers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(30);

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("BoardGames.Models.BoardGamesList", b =>
                {
                    b.HasOne("BoardGames.Models.BoardGameGenre", "Genre")
                        .WithMany("BoardGameLists")
                        .HasForeignKey("GenreId1");

                    b.HasOne("BoardGames.Models.Manufacturers", "Manufacturer")
                        .WithMany("BoardGameLists")
                        .HasForeignKey("ManufacturerId1");
                });
#pragma warning restore 612, 618
        }
    }
}
