using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Gestor.Migrations
{
    /// <inheritdoc />
    public partial class fechasCreac_mod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagenProducto");

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCreacion",
                table: "Producto",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaModificacion",
                table: "Producto",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCreacion",
                table: "Patron",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaModificacion",
                table: "Patron",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCreacion",
                table: "Ingresos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaModificacion",
                table: "Ingresos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCreacion",
                table: "CostoMaterial",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaModificacion",
                table: "CostoMaterial",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fechaCreacion",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "fechaModificacion",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "fechaCreacion",
                table: "Patron");

            migrationBuilder.DropColumn(
                name: "fechaModificacion",
                table: "Patron");

            migrationBuilder.DropColumn(
                name: "fechaCreacion",
                table: "Ingresos");

            migrationBuilder.DropColumn(
                name: "fechaModificacion",
                table: "Ingresos");

            migrationBuilder.DropColumn(
                name: "fechaCreacion",
                table: "CostoMaterial");

            migrationBuilder.DropColumn(
                name: "fechaModificacion",
                table: "CostoMaterial");

            migrationBuilder.CreateTable(
                name: "ImagenProducto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    productoId = table.Column<int>(type: "integer", nullable: false),
                    borrado = table.Column<bool>(type: "boolean", nullable: false),
                    rutaImg = table.Column<string>(type: "text", nullable: false)
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
    }
}
