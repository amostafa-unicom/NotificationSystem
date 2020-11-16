using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotificationHubSystem.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotificationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeleteStatus = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SendingStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeleteStatus = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendingStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationBase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeleteStatus = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ReceiverId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    Exception = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationBase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationBase_SendingStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "SendingStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotificationBase_NotificationType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "NotificationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationId = table.Column<int>(nullable: false),
                    Body = table.Column<string>(nullable: true),
                    Priority = table.Column<byte>(nullable: false),
                    IsHtml = table.Column<bool>(nullable: false),
                    To = table.Column<string>(nullable: true),
                    CC = table.Column<string>(nullable: true),
                    BCC = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mail_NotificationBase_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "NotificationBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PushNotification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    SendData = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PushNotification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PushNotification_NotificationBase_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "NotificationBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SMS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationId = table.Column<int>(nullable: false),
                    Body = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SMS_NotificationBase_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "NotificationBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "NotificationType",
                columns: new[] { "Id", "CreationDate", "DeleteStatus", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 11, 16, 14, 42, 16, 766, DateTimeKind.Local).AddTicks(6367), 0, "Mail" },
                    { 2, new DateTime(2020, 11, 16, 14, 42, 16, 766, DateTimeKind.Local).AddTicks(6654), 0, "PushNotification" },
                    { 3, new DateTime(2020, 11, 16, 14, 42, 16, 766, DateTimeKind.Local).AddTicks(6693), 0, "SMS" }
                });

            migrationBuilder.InsertData(
                table: "SendingStatus",
                columns: new[] { "Id", "CreationDate", "DeleteStatus", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 11, 16, 14, 42, 16, 763, DateTimeKind.Local).AddTicks(4524), 0, "New" },
                    { 2, new DateTime(2020, 11, 16, 14, 42, 16, 766, DateTimeKind.Local).AddTicks(3242), 0, "Success" },
                    { 3, new DateTime(2020, 11, 16, 14, 42, 16, 766, DateTimeKind.Local).AddTicks(3516), 0, "Failed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mail_NotificationId",
                table: "Mail",
                column: "NotificationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationBase_StatusId",
                table: "NotificationBase",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationBase_TypeId",
                table: "NotificationBase",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PushNotification_NotificationId",
                table: "PushNotification",
                column: "NotificationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SMS_NotificationId",
                table: "SMS",
                column: "NotificationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mail");

            migrationBuilder.DropTable(
                name: "PushNotification");

            migrationBuilder.DropTable(
                name: "SMS");

            migrationBuilder.DropTable(
                name: "NotificationBase");

            migrationBuilder.DropTable(
                name: "SendingStatus");

            migrationBuilder.DropTable(
                name: "NotificationType");
        }
    }
}
