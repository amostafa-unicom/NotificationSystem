using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotificationHubSystem.Infrastructure.Migrations
{
    public partial class notificationTokenId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NotificationTokenId",
                table: "PushNotification",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 11, 16, 15, 41, 22, 682, DateTimeKind.Local).AddTicks(7154));

            migrationBuilder.UpdateData(
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2020, 11, 16, 15, 41, 22, 682, DateTimeKind.Local).AddTicks(7474));

            migrationBuilder.UpdateData(
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2020, 11, 16, 15, 41, 22, 682, DateTimeKind.Local).AddTicks(7509));

            migrationBuilder.UpdateData(
                table: "SendingStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 11, 16, 15, 41, 22, 680, DateTimeKind.Local).AddTicks(873));

            migrationBuilder.UpdateData(
                table: "SendingStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2020, 11, 16, 15, 41, 22, 682, DateTimeKind.Local).AddTicks(4344));

            migrationBuilder.UpdateData(
                table: "SendingStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2020, 11, 16, 15, 41, 22, 682, DateTimeKind.Local).AddTicks(4551));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotificationTokenId",
                table: "PushNotification");

            migrationBuilder.UpdateData(
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 11, 16, 14, 42, 16, 766, DateTimeKind.Local).AddTicks(6367));

            migrationBuilder.UpdateData(
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2020, 11, 16, 14, 42, 16, 766, DateTimeKind.Local).AddTicks(6654));

            migrationBuilder.UpdateData(
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2020, 11, 16, 14, 42, 16, 766, DateTimeKind.Local).AddTicks(6693));

            migrationBuilder.UpdateData(
                table: "SendingStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 11, 16, 14, 42, 16, 763, DateTimeKind.Local).AddTicks(4524));

            migrationBuilder.UpdateData(
                table: "SendingStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2020, 11, 16, 14, 42, 16, 766, DateTimeKind.Local).AddTicks(3242));

            migrationBuilder.UpdateData(
                table: "SendingStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2020, 11, 16, 14, 42, 16, 766, DateTimeKind.Local).AddTicks(3516));
        }
    }
}
