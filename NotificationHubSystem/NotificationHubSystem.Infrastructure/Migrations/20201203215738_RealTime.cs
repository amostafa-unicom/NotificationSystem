using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotificationHubSystem.Infrastructure.Migrations
{
    public partial class RealTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RealTime",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationId = table.Column<int>(nullable: false),
                    Event = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealTime_NotificationBase_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "NotificationBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_RealTime_NotificationId",
                table: "RealTime",
                column: "NotificationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealTime");

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
    }
}
