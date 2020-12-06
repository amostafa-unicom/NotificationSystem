using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotificationHubSystem.Infrastructure.Migrations
{
    public partial class mailSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Mail");

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Mail",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Mail");

            migrationBuilder.AddColumn<byte>(
                name: "Priority",
                table: "Mail",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

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

            migrationBuilder.UpdateData(
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2020, 12, 4, 0, 48, 45, 68, DateTimeKind.Local).AddTicks(2495));

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
    }
}
