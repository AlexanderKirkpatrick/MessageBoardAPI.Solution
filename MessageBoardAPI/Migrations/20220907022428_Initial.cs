using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageBoardAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Group = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Author = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Author", "Body", "Date", "Group" },
                values: new object[,]
                {
                    { 1, "Mark", "This is a test message", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TEST" },
                    { 2, "Mark", "This is a test message", new DateTime(2022, 1, 1, 10, 10, 10, 0, DateTimeKind.Unspecified), "TEST 1" },
                    { 3, "Mark", "This is a test message", new DateTime(2022, 1, 1, 10, 10, 10, 0, DateTimeKind.Unspecified), "TEST" },
                    { 4, "Jack", "This is a test message", new DateTime(2022, 1, 1, 10, 10, 10, 0, DateTimeKind.Unspecified), "TEST 1" },
                    { 5, "Jack", "This is a test message", new DateTime(2022, 1, 1, 10, 10, 10, 0, DateTimeKind.Unspecified), "TEST" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
