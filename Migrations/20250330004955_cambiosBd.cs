using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestor.Migrations
{
    /// <inheritdoc />
    public partial class cambiosBd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "descripcion",
                table: "Tipo_punto");

            migrationBuilder.DropColumn(
                name: "color",
                table: "Patron");

            migrationBuilder.DropColumn(
                name: "punto",
                table: "Patron");

            migrationBuilder.DropColumn(
                name: "vuelta",
                table: "Patron");

            migrationBuilder.AddColumn<string>(
                name: "color",
                table: "Tipo_punto",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "eliminado",
                table: "Tipo_punto",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCreacion",
                table: "Tipo_punto",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaModificacion",
                table: "Tipo_punto",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "idPatronId",
                table: "Tipo_punto",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "vuelta",
                table: "Tipo_punto",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tipo_punto_idPatronId",
                table: "Tipo_punto",
                column: "idPatronId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tipo_punto_Patron_idPatronId",
                table: "Tipo_punto",
                column: "idPatronId",
                principalTable: "Patron",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tipo_punto_Patron_idPatronId",
                table: "Tipo_punto");

            migrationBuilder.DropIndex(
                name: "IX_Tipo_punto_idPatronId",
                table: "Tipo_punto");

            migrationBuilder.DropColumn(
                name: "color",
                table: "Tipo_punto");

            migrationBuilder.DropColumn(
                name: "eliminado",
                table: "Tipo_punto");

            migrationBuilder.DropColumn(
                name: "fechaCreacion",
                table: "Tipo_punto");

            migrationBuilder.DropColumn(
                name: "fechaModificacion",
                table: "Tipo_punto");

            migrationBuilder.DropColumn(
                name: "idPatronId",
                table: "Tipo_punto");

            migrationBuilder.DropColumn(
                name: "vuelta",
                table: "Tipo_punto");

            migrationBuilder.AddColumn<string>(
                name: "descripcion",
                table: "Tipo_punto",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "color",
                table: "Patron",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "punto",
                table: "Patron",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "vuelta",
                table: "Patron",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
