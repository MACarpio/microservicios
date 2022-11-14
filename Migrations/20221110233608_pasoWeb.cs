using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ms.Migrations
{
    public partial class pasoWeb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "pasoWeb",
                table: "md_busquedas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pasoWeb",
                table: "md_busquedas");
        }
    }
}
