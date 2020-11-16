using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotificationHubSystem.Infrastructure.Migrations
{
    public partial class body : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Body",
                table: "SMS");

            migrationBuilder.DropColumn(
                name: "Body",
                table: "PushNotification");

            migrationBuilder.DropColumn(
                name: "Body",
                table: "Mail");

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "NotificationBase",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 11, 16, 22, 42, 20, 53, DateTimeKind.Local).AddTicks(5633));

            migrationBuilder.UpdateData(
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2020, 11, 16, 22, 42, 20, 53, DateTimeKind.Local).AddTicks(5998));

            migrationBuilder.UpdateData(
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2020, 11, 16, 22, 42, 20, 53, DateTimeKind.Local).AddTicks(6065));

            migrationBuilder.UpdateData(
                table: "SendingStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 11, 16, 22, 42, 20, 50, DateTimeKind.Local).AddTicks(1217));

            migrationBuilder.UpdateData(
                table: "SendingStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2020, 11, 16, 22, 42, 20, 53, DateTimeKind.Local).AddTicks(1970));

            migrationBuilder.UpdateData(
                table: "SendingStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2020, 11, 16, 22, 42, 20, 53, DateTimeKind.Local).AddTicks(2272));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Body",
                table: "NotificationBase");

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "SMS",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "PushNotification",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "Mail",
                type: "nvarchar(max)",
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
    }
}
