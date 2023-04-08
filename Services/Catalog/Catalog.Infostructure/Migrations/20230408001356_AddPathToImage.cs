using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Infostructure.Migrations
{
    public partial class AddPathToImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Wigwams",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "Wigwams");
        }
    }
}
