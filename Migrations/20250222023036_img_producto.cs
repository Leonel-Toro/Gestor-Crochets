using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestor.Migrations
{
    /// <inheritdoc />
    public partial class img_producto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "path_img_principal",
                table: "Producto",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "path_img_secundaria",
                table: "Producto",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "path_img_terciaria",
                table: "Producto",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "path_img_principal",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "path_img_secundaria",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "path_img_terciaria",
                table: "Producto");
        }
    }
}
