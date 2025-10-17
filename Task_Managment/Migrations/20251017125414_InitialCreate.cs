using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_Managment.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsCompleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "Id", "CreatedAt", "Description", "Title" },
                values: new object[] { 1, new DateTime(2025, 10, 17, 12, 54, 14, 449, DateTimeKind.Utc).AddTicks(2294), "Ознакомиться с основами создания REST API", "Изучить ASP.NET Core" });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "Id", "CreatedAt", "Description", "IsCompleted", "Title" },
                values: new object[] { 2, new DateTime(2025, 10, 17, 12, 54, 14, 449, DateTimeKind.Utc).AddTicks(2445), "Создать миграции и подключить базу данных", true, "Настроить Entity Framework" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskItems");
        }
    }
}
