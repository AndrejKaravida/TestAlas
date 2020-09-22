using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnglishTexts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnglishTexts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SerbianTexts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    EnglishTextId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerbianTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SerbianTexts_EnglishTexts_EnglishTextId",
                        column: x => x.EnglishTextId,
                        principalTable: "EnglishTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SerbianTexts_EnglishTextId",
                table: "SerbianTexts",
                column: "EnglishTextId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SerbianTexts");

            migrationBuilder.DropTable(
                name: "EnglishTexts");
        }
    }
}
