using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BoardGames.Migrations
{
    public partial class Dev4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardGameGenre_BoardGamesList_BoardGameListsId",
                table: "BoardGameGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardGamesList_Manufacturers_ManufacturerId",
                table: "BoardGamesList");

            migrationBuilder.DropIndex(
                name: "IX_BoardGameGenre_BoardGameListsId",
                table: "BoardGameGenre");

            migrationBuilder.DropColumn(
                name: "BoardGameListsId",
                table: "BoardGameGenre");

            migrationBuilder.RenameColumn(
                name: "ManufacturerId",
                table: "BoardGamesList",
                newName: "ManufacturerId1");

            migrationBuilder.RenameIndex(
                name: "IX_BoardGamesList_ManufacturerId",
                table: "BoardGamesList",
                newName: "IX_BoardGamesList_ManufacturerId1");

            migrationBuilder.AddColumn<int>(
                name: "GenreId1",
                table: "BoardGamesList",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardGamesList_GenreId1",
                table: "BoardGamesList",
                column: "GenreId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGamesList_BoardGameGenre_GenreId1",
                table: "BoardGamesList",
                column: "GenreId1",
                principalTable: "BoardGameGenre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGamesList_Manufacturers_ManufacturerId1",
                table: "BoardGamesList",
                column: "ManufacturerId1",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardGamesList_BoardGameGenre_GenreId1",
                table: "BoardGamesList");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardGamesList_Manufacturers_ManufacturerId1",
                table: "BoardGamesList");

            migrationBuilder.DropIndex(
                name: "IX_BoardGamesList_GenreId1",
                table: "BoardGamesList");

            migrationBuilder.DropColumn(
                name: "GenreId1",
                table: "BoardGamesList");

            migrationBuilder.RenameColumn(
                name: "ManufacturerId1",
                table: "BoardGamesList",
                newName: "ManufacturerId");

            migrationBuilder.RenameIndex(
                name: "IX_BoardGamesList_ManufacturerId1",
                table: "BoardGamesList",
                newName: "IX_BoardGamesList_ManufacturerId");

            migrationBuilder.AddColumn<int>(
                name: "BoardGameListsId",
                table: "BoardGameGenre",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardGameGenre_BoardGameListsId",
                table: "BoardGameGenre",
                column: "BoardGameListsId",
                unique: true,
                filter: "[BoardGameListsId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGameGenre_BoardGamesList_BoardGameListsId",
                table: "BoardGameGenre",
                column: "BoardGameListsId",
                principalTable: "BoardGamesList",
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
    }
}
