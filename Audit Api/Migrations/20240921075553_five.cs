using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Audit_Api.Migrations
{
    /// <inheritdoc />
    public partial class five : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Audits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 9, 21, 11, 55, 51, 21, DateTimeKind.Local).AddTicks(9972));

            migrationBuilder.UpdateData(
                table: "Audits",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 9, 21, 11, 55, 51, 21, DateTimeKind.Local).AddTicks(9983));

            migrationBuilder.UpdateData(
                table: "Audits",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2024, 9, 21, 11, 55, 51, 21, DateTimeKind.Local).AddTicks(9984));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Audits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 9, 21, 1, 39, 59, 133, DateTimeKind.Local).AddTicks(5637));

            migrationBuilder.UpdateData(
                table: "Audits",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 9, 21, 1, 39, 59, 133, DateTimeKind.Local).AddTicks(5653));

            migrationBuilder.UpdateData(
                table: "Audits",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2024, 9, 21, 1, 39, 59, 133, DateTimeKind.Local).AddTicks(5656));
        }
    }
}
