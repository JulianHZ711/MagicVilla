using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class AlimentarTablaVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagenUrl", "MetrosCuadrados", "Nombre", "Tarifa", "ocupantes" },
                values: new object[,]
                {
                    { 1, "", "Detalle de la Villa...", new DateTime(2025, 1, 10, 10, 37, 9, 969, DateTimeKind.Local).AddTicks(2831), new DateTime(2025, 1, 10, 10, 37, 9, 969, DateTimeKind.Local).AddTicks(2821), "", 50, "Vista Real", 200.0, 5 },
                    { 2, "", "Detalle de la Villa...", new DateTime(2025, 1, 10, 10, 37, 9, 969, DateTimeKind.Local).AddTicks(2834), new DateTime(2025, 1, 10, 10, 37, 9, 969, DateTimeKind.Local).AddTicks(2834), "", 40, "Vista a la Piscibna", 150.0, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
