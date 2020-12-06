using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotificationHubSystem.Infrastructure.Migrations
{
    public partial class Recipient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Recipient",
                table: "SMS",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 12, 6, 21, 31, 43, 932, DateTimeKind.Local).AddTicks(1702));

            migrationBuilder.UpdateData(
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2020, 12, 6, 21, 31, 43, 932, DateTimeKind.Local).AddTicks(2427));

            migrationBuilder.UpdateData(
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2020, 12, 6, 21, 31, 43, 932, DateTimeKind.Local).AddTicks(2589));

            migrationBuilder.UpdateData(
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2020, 12, 6, 21, 31, 43, 932, DateTimeKind.Local).AddTicks(2701));

            migrationBuilder.UpdateData(
                table: "SendingStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 12, 6, 21, 31, 43, 927, DateTimeKind.Local).AddTicks(1503));

            migrationBuilder.UpdateData(
                table: "SendingStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2020, 12, 6, 21, 31, 43, 931, DateTimeKind.Local).AddTicks(5989));

            migrationBuilder.UpdateData(
                table: "SendingStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2020, 12, 6, 21, 31, 43, 931, DateTimeKind.Local).AddTicks(6493));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Recipient",
                table: "SMS");

            migrationBuilder.UpdateData(
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 12, 6, 16, 19, 29, 803, DateTimeKind.Local).AddTicks(3496));

            migrationBuilder.UpdateData(
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2020, 12, 6, 16, 19, 29, 803, DateTimeKind.Local).AddTicks(4288));

            migrationBuilder.UpdateData(
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2020, 12, 6, 16, 19, 29, 803, DateTimeKind.Local).AddTicks(4450));

            migrationBuilder.UpdateData(
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2020, 12, 6, 16, 19, 29, 803, DateTimeKind.Local).AddTicks(4810));

            migrationBuilder.UpdateData(
                table: "SendingStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 12, 6, 16, 19, 29, 799, DateTimeKind.Local).AddTicks(231));

            migrationBuilder.UpdateData(
                table: "SendingStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2020, 12, 6, 16, 19, 29, 802, DateTimeKind.Local).AddTicks(6929));

            migrationBuilder.UpdateData(
                table: "SendingStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2020, 12, 6, 16, 19, 29, 802, DateTimeKind.Local).AddTicks(7531));
        }
    }
}
