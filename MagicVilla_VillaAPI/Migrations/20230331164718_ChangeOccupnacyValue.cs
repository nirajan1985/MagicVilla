using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOccupnacyValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 31, 18, 47, 18, 574, DateTimeKind.Local).AddTicks(1070));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 31, 18, 47, 18, 574, DateTimeKind.Local).AddTicks(1157));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 31, 18, 47, 18, 574, DateTimeKind.Local).AddTicks(1162));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 31, 18, 47, 18, 574, DateTimeKind.Local).AddTicks(1167));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Occupancy" },
                values: new object[] { new DateTime(2023, 3, 31, 18, 47, 18, 574, DateTimeKind.Local).AddTicks(1171), 3 });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "Occupancy" },
                values: new object[] { new DateTime(2023, 3, 31, 18, 47, 18, 574, DateTimeKind.Local).AddTicks(1176), 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 28, 12, 31, 2, 29, DateTimeKind.Local).AddTicks(3701));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 28, 12, 31, 2, 29, DateTimeKind.Local).AddTicks(3769));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 28, 12, 31, 2, 29, DateTimeKind.Local).AddTicks(3774));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 28, 12, 31, 2, 29, DateTimeKind.Local).AddTicks(3778));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Occupancy" },
                values: new object[] { new DateTime(2023, 3, 28, 12, 31, 2, 29, DateTimeKind.Local).AddTicks(3782), 4 });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "Occupancy" },
                values: new object[] { new DateTime(2023, 3, 28, 12, 31, 2, 29, DateTimeKind.Local).AddTicks(3787), 4 });
        }
    }
}
