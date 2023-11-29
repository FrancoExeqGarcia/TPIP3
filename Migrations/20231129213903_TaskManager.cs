using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TODOLIST.Migrations
{
    public partial class TaskManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Project_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToDo",
                columns: table => new
                {
                    ToDoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Completed = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDo", x => x.ToDoId);
                    table.ForeignKey(
                        name: "FK_ToDo_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToDo_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "Description", "EndDate", "Name", "StartDate", "UserId" },
                values: new object[,]
                {
                    { 1, "Project from USA", new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project1", new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, "Project from EU", new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project3", new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Password", "State", "UserName", "UserType" },
                values: new object[,]
                {
                    { 2, "francoexequiel.garcia150@gmail.com", "123456", true, "exegar", "Admin" },
                    { 1, "ramirodicarlo2@gmail.com", "123456", true, "rdic", "Programer" },
                    { 3, "superadmin@gmail.com", "123456", true, "superadmin", "SuperAdmin" }
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "Description", "EndDate", "Name", "StartDate", "UserId" },
                values: new object[] { 2, "Project from Arg", new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project2", new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.InsertData(
                table: "ToDo",
                columns: new[] { "ToDoId", "Completed", "EndDate", "Name", "ProjectId", "StartDate", "UserId" },
                values: new object[] { 1, false, new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Controlers", 1, new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "ToDo",
                columns: new[] { "ToDoId", "Completed", "EndDate", "Name", "ProjectId", "StartDate", "UserId" },
                values: new object[] { 3, false, new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Services", 3, new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 });

            migrationBuilder.InsertData(
                table: "ToDo",
                columns: new[] { "ToDoId", "Completed", "EndDate", "Name", "ProjectId", "StartDate", "UserId" },
                values: new object[] { 2, false, new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Entities", 2, new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Project_UserId",
                table: "Project",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_ProjectId",
                table: "ToDo",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_UserId",
                table: "ToDo",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDo");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
