using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ms.Migrations
{
    public partial class sv_pr1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nro_doc",
                table: "md_sv",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nro_doc",
                table: "md_sv");
        }
    }
}
