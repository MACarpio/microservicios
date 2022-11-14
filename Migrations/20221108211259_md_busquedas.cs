using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ms.Migrations
{
    public partial class md_busquedas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "md_busquedas",
                columns: table => new
                {
                    id_busqueda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ide_cliente = table.Column<int>(type: "int", nullable: false),
                    latitud = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    longitud = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    torre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bloque = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipo_interes_Id = table.Column<int>(type: "int", nullable: true),
                    vendedorId = table.Column<int>(type: "int", nullable: true),
                    observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_md_busquedas", x => x.id_busqueda);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "md_busquedas");
        }
    }
}
