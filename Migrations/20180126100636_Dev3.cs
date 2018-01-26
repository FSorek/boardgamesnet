using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BoardGames.Migrations
{
    public partial class Dev3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardGamesList_BoardGameGenre_GenreId",
                table: "BoardGamesList");

            migrationBuilder.DropIndex(
                name: "IX_BoardGamesList_GenreId",
                table: "BoardGamesList");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "BoardGamesList");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardGameGenre_BoardGamesList_BoardGameListsId",
                table: "BoardGameGenre");

            migrationBuilder.DropIndex(
                name: "IX_BoardGameGenre_BoardGameListsId",
                table: "BoardGameGenre");

            migrationBuilder.DropColumn(
                name: "BoardGameListsId",
                table: "BoardGameGenre");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "BoardGamesList",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardGamesList_GenreId",
                table: "BoardGamesList",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGamesList_BoardGameGenre_GenreId",
                table: "BoardGamesList",
                column: "GenreId",
                principalTable: "BoardGameGenre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
