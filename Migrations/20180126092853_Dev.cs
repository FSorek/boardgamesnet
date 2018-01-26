using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BoardGames.Migrations
{
    public partial class Dev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "BoardGamesList");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "BoardGamesList",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManufacturerId",
                table: "BoardGamesList",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BoardGameGenre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGameGenre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardGamesList_GenreId",
                table: "BoardGamesList",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGamesList_ManufacturerId",
                table: "BoardGamesList",
                column: "ManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGamesList_BoardGameGenre_GenreId",
                table: "BoardGamesList",
                column: "GenreId",
                principalTable: "BoardGameGenre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGamesList_Manufacturers_ManufacturerId",
                table: "BoardGamesList",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardGamesList_BoardGameGenre_GenreId",
                table: "BoardGamesList");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardGamesList_Manufacturers_ManufacturerId",
                table: "BoardGamesList");

            migrationBuilder.DropTable(
                name: "BoardGameGenre");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropIndex(
                name: "IX_BoardGamesList_GenreId",
                table: "BoardGamesList");

            migrationBuilder.DropIndex(
                name: "IX_BoardGamesList_ManufacturerId",
                table: "BoardGamesList");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "BoardGamesList");

            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "BoardGamesList");

            migrationBuilder.AddColumn<int>(
                name: "Genre",
                table: "BoardGamesList",
                nullable: false,
                defaultValue: 0);
        }
    }
}
