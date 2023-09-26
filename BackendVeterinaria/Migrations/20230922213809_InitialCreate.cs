using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Veterinaria.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    PropietarioId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombres = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Apellidos = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Documento = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Genero = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.PropietarioId);
                });

            migrationBuilder.CreateTable(
                name: "raza",
                columns: table => new
                {
                    RazaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DescripcionRaza = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_raza", x => x.RazaId);
                });

            migrationBuilder.CreateTable(
                name: "tipo",
                columns: table => new
                {
                    TipoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DescripcionTipo = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo", x => x.TipoId);
                });

            migrationBuilder.CreateTable(
                name: "mascota",
                columns: table => new
                {
                    MascotaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PropietarioId = table.Column<int>(type: "integer", maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    TipoId = table.Column<int>(type: "integer", maxLength: 20, nullable: false),
                    RazaId = table.Column<int>(type: "integer", maxLength: 20, nullable: false),
                    PesoLb = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Genero = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mascota", x => x.MascotaId);
                    table.ForeignKey(
                        name: "FK_mascota_cliente_PropietarioId",
                        column: x => x.PropietarioId,
                        principalTable: "cliente",
                        principalColumn: "PropietarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mascota_raza_RazaId",
                        column: x => x.RazaId,
                        principalTable: "raza",
                        principalColumn: "RazaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mascota_tipo_TipoId",
                        column: x => x.TipoId,
                        principalTable: "tipo",
                        principalColumn: "TipoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mascota_PropietarioId",
                table: "mascota",
                column: "PropietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_mascota_RazaId",
                table: "mascota",
                column: "RazaId");

            migrationBuilder.CreateIndex(
                name: "IX_mascota_TipoId",
                table: "mascota",
                column: "TipoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mascota");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "raza");

            migrationBuilder.DropTable(
                name: "tipo");
        }
    }
}
