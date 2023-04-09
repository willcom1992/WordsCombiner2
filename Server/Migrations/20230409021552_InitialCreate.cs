using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WordsCombiner.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JapaneseWords",
                columns: table => new
                {
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PartOfSpeech = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JapaneseWords", x => x.Value);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JapaneseWords");
        }
    }
}
