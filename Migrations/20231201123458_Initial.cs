using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TODOLIST.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    UserType = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false),
                    State = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AdminProject",
                columns: table => new
                {
                    AdminsUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProjectsProjectId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminProject", x => new { x.AdminsUserId, x.ProjectsProjectId });
                    table.ForeignKey(
                        name: "FK_AdminProject_Project_ProjectsProjectId",
                        column: x => x.ProjectsProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminProject_Users_AdminsUserId",
                        column: x => x.AdminsUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToDo",
                columns: table => new
                {
                    ToDoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProgramerUserId = table.Column<int>(type: "INTEGER", nullable: true)
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
                        name: "FK_ToDo_Users_ProgramerUserId",
                        column: x => x.ProgramerUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "Description", "EndDate", "Name", "StartDate" },
                values: new object[] { 1, "Project from USA", new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project1", new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "Description", "EndDate", "Name", "StartDate" },
                values: new object[] { 2, "Project from Arg", new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project2", new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "Description", "EndDate", "Name", "StartDate" },
                values: new object[] { 3, "Project from EU", new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project3", new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Password", "Role", "State", "UserName", "UserType" },
                values: new object[] { 2, "francoexequiel.garcia150@gmail.com", "123456", 0, true, "exegar", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Password", "Role", "State", "UserName", "UserType" },
                values: new object[] { 1, "ramirodicarlo2@gmail.com", "123456", 0, true, "rdic", "Programer" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Password", "Role", "State", "UserName", "UserType" },
                values: new object[] { 3, "superadmin@gmail.com", "123456", 0, true, "superadmin", "SuperAdmin" });

            migrationBuilder.InsertData(
                table: "ToDo",
                columns: new[] { "ToDoId", "EndDate", "Name", "ProgramerUserId", "ProjectId", "StartDate" },
                values: new object[] { 1, new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Controlers", null, 1, new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ToDo",
                columns: new[] { "ToDoId", "EndDate", "Name", "ProgramerUserId", "ProjectId", "StartDate" },
                values: new object[] { 2, new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Entities", null, 2, new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ToDo",
                columns: new[] { "ToDoId", "EndDate", "Name", "ProgramerUserId", "ProjectId", "StartDate" },
                values: new object[] { 3, new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Services", null, 3, new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_AdminProject_ProjectsProjectId",
                table: "AdminProject",
                column: "ProjectsProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_ProgramerUserId",
                table: "ToDo",
                column: "ProgramerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_ProjectId",
                table: "ToDo",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminProject");

            migrationBuilder.DropTable(
                name: "ToDo");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
