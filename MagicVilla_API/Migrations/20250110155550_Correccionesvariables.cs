using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class Correccionesvariables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2025, 1, 10, 10, 55, 49, 908, DateTimeKind.Local).AddTicks(6923), new DateTime(2025, 1, 10, 10, 55, 49, 908, DateTimeKind.Local).AddTicks(6908) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2025, 1, 10, 10, 55, 49, 908, DateTimeKind.Local).AddTicks(6927), new DateTime(2025, 1, 10, 10, 55, 49, 908, DateTimeKind.Local).AddTicks(6926) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2025, 1, 10, 10, 37, 9, 969, DateTimeKind.Local).AddTicks(2831), new DateTime(2025, 1, 10, 10, 37, 9, 969, DateTimeKind.Local).AddTicks(2821) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2025, 1, 10, 10, 37, 9, 969, DateTimeKind.Local).AddTicks(2834), new DateTime(2025, 1, 10, 10, 37, 9, 969, DateTimeKind.Local).AddTicks(2834) });
        }
    }
}
