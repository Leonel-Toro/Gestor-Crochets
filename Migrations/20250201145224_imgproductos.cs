using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Gestor.Migrations
{
    /// <inheritdoc />
    public partial class imgproductos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgRuta",
                table: "Producto");

            migrationBuilder.CreateTable(
                name: "ImagenProducto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    productoId = table.Column<int>(type: "integer", nullable: false),
                    rutaImg = table.Column<string>(type: "text", nullable: false),
                    borrado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagenProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagenProducto_Producto_productoId",
                        column: x => x.productoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagenProducto_productoId",
                table: "ImagenProducto",
                column: "productoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagenProducto");

            migrationBuilder.AddColumn<string>(
                name: "ImgRuta",
                table: "Producto",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
