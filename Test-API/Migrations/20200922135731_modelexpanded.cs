using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApi.Migrations
{
    public partial class modelexpanded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "From",
                table: "TranslationResults",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "TranslationResults",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "To",
                table: "TranslationResults",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                table: "TranslationResults");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "TranslationResults");

            migrationBuilder.DropColumn(
                name: "To",
                table: "TranslationResults");
        }
    }
}
