using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QueueTaskStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueueTaskStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QueueTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PercentComplete = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Name = table.Column<string>(type: "nvarchar(300)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "getdate()"),
                    CompleteDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    QueueTaskStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueueTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QueueTasks_QueueTaskStatuses_QueueTaskStatusId",
                        column: x => x.QueueTaskStatusId,
                        principalTable: "QueueTaskStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "QueueTaskStatuses",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Создана. Ожидает начала работы", "WaitingToStart" },
                    { 2, "Выполняется", "InProgress" },
                    { 3, "Завершена", "Complete" },
                    { 4, "Пауза", "Pause" },
                    { 5, "Ошибка", "Error" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_QueueTasks_QueueTaskStatusId",
                table: "QueueTasks",
                column: "QueueTaskStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QueueTasks");

            migrationBuilder.DropTable(
                name: "QueueTaskStatuses");
        }
    }
}
