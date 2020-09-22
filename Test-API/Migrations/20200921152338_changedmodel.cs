using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApi.Migrations
{
    public partial class changedmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SerbianTexts");

            migrationBuilder.DropTable(
                name: "EnglishTexts");

            migrationBuilder.CreateTable(
                name: "TranslationResults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerbianText = table.Column<string>(nullable: true),
                    EnglishText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationResults", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TranslationResults");

            migrationBuilder.CreateTable(
                name: "EnglishTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnglishTexts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SerbianTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnglishTextId = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
    }
}
