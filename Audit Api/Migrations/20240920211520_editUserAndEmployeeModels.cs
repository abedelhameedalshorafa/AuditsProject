using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Audit_Api.Migrations
{
    /// <inheritdoc />
    public partial class editUserAndEmployeeModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Audits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 9, 21, 1, 15, 18, 258, DateTimeKind.Local).AddTicks(4549));

            migrationBuilder.UpdateData(
                table: "Audits",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 9, 21, 1, 15, 18, 258, DateTimeKind.Local).AddTicks(4581));

            migrationBuilder.UpdateData(
                table: "Audits",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2024, 9, 21, 1, 15, 18, 258, DateTimeKind.Local).AddTicks(4586));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Audits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 9, 20, 18, 2, 8, 376, DateTimeKind.Local).AddTicks(6597));

            migrationBuilder.UpdateData(
                table: "Audits",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 9, 20, 18, 2, 8, 376, DateTimeKind.Local).AddTicks(6611));

            migrationBuilder.UpdateData(
                table: "Audits",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2024, 9, 20, 18, 2, 8, 376, DateTimeKind.Local).AddTicks(6613));
        }
    }
}
