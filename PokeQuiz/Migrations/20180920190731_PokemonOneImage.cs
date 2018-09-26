using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PokeQuiz.Migrations
{
    public partial class PokemonOneImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HiddenImage",
                table: "Pokemon");

            migrationBuilder.RenameColumn(
                name: "PublicImage",
                table: "Pokemon",
                newName: "Image");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Pokemon",
                newName: "PublicImage");

            migrationBuilder.AddColumn<byte[]>(
                name: "HiddenImage",
                table: "Pokemon",
                nullable: true);
        }
    }
}
