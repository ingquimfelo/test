using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UCP.App.Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parqueaderos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numeroPuestos = table.Column<int>(type: "int", nullable: false),
                    horario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    picoPlaca = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parqueaderos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipoVehiculo = table.Column<int>(type: "int", nullable: false),
                    placa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    identificacion = table.Column<int>(type: "int", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vehiculo_1id = table.Column<int>(type: "int", nullable: true),
                    vehiculo_2id = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parqueaderoid = table.Column<int>(type: "int", nullable: true),
                    programa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oficina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dependencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    facultad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    departamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cubiculo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    actividad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    autoriza = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Personas_Parqueaderos_Parqueaderoid",
                        column: x => x.Parqueaderoid,
                        principalTable: "Parqueaderos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personas_Vehiculo_vehiculo_1id",
                        column: x => x.vehiculo_1id,
                        principalTable: "Vehiculo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personas_Vehiculo_vehiculo_2id",
                        column: x => x.vehiculo_2id,
                        principalTable: "Vehiculo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Puestos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoVehiculo = table.Column<int>(type: "int", nullable: false),
                    numeroParqueadero = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    vehiculoid = table.Column<int>(type: "int", nullable: true),
                    Parqueaderoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puestos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Puestos_Parqueaderos_Parqueaderoid",
                        column: x => x.Parqueaderoid,
                        principalTable: "Parqueaderos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Puestos_Vehiculo_vehiculoid",
                        column: x => x.vehiculoid,
                        principalTable: "Vehiculo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    horaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    horaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    valorHora = table.Column<float>(type: "real", nullable: false),
                    vehiculoid = table.Column<int>(type: "int", nullable: true),
                    Parqueaderoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.id);
                    table.ForeignKey(
                        name: "FK_Transacciones_Parqueaderos_Parqueaderoid",
                        column: x => x.Parqueaderoid,
                        principalTable: "Parqueaderos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transacciones_Vehiculo_vehiculoid",
                        column: x => x.vehiculoid,
                        principalTable: "Vehiculo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Parqueaderoid",
                table: "Personas",
                column: "Parqueaderoid");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_vehiculo_1id",
                table: "Personas",
                column: "vehiculo_1id");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_vehiculo_2id",
                table: "Personas",
                column: "vehiculo_2id");

            migrationBuilder.CreateIndex(
                name: "IX_Puestos_Parqueaderoid",
                table: "Puestos",
                column: "Parqueaderoid");

            migrationBuilder.CreateIndex(
                name: "IX_Puestos_vehiculoid",
                table: "Puestos",
                column: "vehiculoid");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_Parqueaderoid",
                table: "Transacciones",
                column: "Parqueaderoid");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_vehiculoid",
                table: "Transacciones",
                column: "vehiculoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Puestos");

            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "Parqueaderos");

            migrationBuilder.DropTable(
                name: "Vehiculo");
        }
    }
}
