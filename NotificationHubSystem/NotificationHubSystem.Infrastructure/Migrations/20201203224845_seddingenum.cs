using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotificationHubSystem.Infrastructure.Migrations
{
    public partial class seddingenum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 12, 4, 0, 48, 45, 68, DateTimeKind.Local).AddTicks(1839));

            migrationBuilder.UpdateData(
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2020, 12, 4, 0, 48, 45, 68, DateTimeKind.Local).AddTicks(2351));

            migrationBuilder.UpdateData(
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2020, 12, 4, 0, 48, 45, 68, DateTimeKind.Local).AddTicks(2442));

            migrationBuilder.InsertData(
                table: "NotificationType",
                columns: new[] { "Id", "CreationDate", "DeleteStatus", "Name" },
                values: new object[] { 4, new DateTime(2020, 12, 4, 0, 48, 45, 68, DateTimeKind.Local).AddTicks(2495), 0, "RealTime" });

            migrationBuilder.UpdateData(
                table: "SendingStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 12, 4, 0, 48, 45, 63, DateTimeKind.Local).AddTicks(4089));

            migrationBuilder.UpdateData(
                table: "SendingStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2020, 12, 4, 0, 48, 45, 67, DateTimeKind.Local).AddTicks(5820));

            migrationBuilder.UpdateData(
                table: "SendingStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2020, 12, 4, 0, 48, 45, 67, DateTimeKind.Local).AddTicks(6445));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 12, 3, 23, 57, 38, 188, DateTimeKind.Local).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2020, 12, 3, 23, 57, 38, 188, DateTimeKind.Local).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2020, 12, 3, 23, 57, 38, 188, DateTimeKind.Local).AddTicks(2694));

            migrationBuilder.UpdateData(
                table: "SendingStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 12, 3, 23, 57, 38, 183, DateTimeKind.Local).AddTicks(4157));

            migrationBuilder.UpdateData(
                table: "SendingStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2020, 12, 3, 23, 57, 38, 187, DateTimeKind.Local).AddTicks(7658));

            migrationBuilder.UpdateData(
                table: "SendingStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2020, 12, 3, 23, 57, 38, 187, DateTimeKind.Local).AddTicks(8262));
        }
    }
}
