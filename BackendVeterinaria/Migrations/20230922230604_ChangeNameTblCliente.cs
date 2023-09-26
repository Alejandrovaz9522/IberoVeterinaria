using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veterinaria.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameTblCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mascota_cliente_PropietarioId",
                table: "mascota");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cliente",
                table: "cliente");

            migrationBuilder.RenameTable(
                name: "cliente",
                newName: "propietario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_propietario",
                table: "propietario",
                column: "PropietarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_mascota_propietario_PropietarioId",
                table: "mascota",
                column: "PropietarioId",
                principalTable: "propietario",
                principalColumn: "PropietarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mascota_propietario_PropietarioId",
                table: "mascota");

            migrationBuilder.DropPrimaryKey(
                name: "PK_propietario",
                table: "propietario");

            migrationBuilder.RenameTable(
                name: "propietario",
                newName: "cliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cliente",
                table: "cliente",
                column: "PropietarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_mascota_cliente_PropietarioId",
                table: "mascota",
                column: "PropietarioId",
                principalTable: "cliente",
                principalColumn: "PropietarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
