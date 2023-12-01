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
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<bool>(type: "INTEGER", nullable: false),
                    AdminUserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Project_Users_AdminUserId",
                        column: x => x.AdminUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
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
                    ProjectRelatedID = table.Column<int>(type: "INTEGER", nullable: false),
                    State = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDo", x => x.ToDoId);
                    table.ForeignKey(
                        name: "FK_ToDo_Project_ProjectRelatedID",
                        column: x => x.ProjectRelatedID,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToDo_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "AdminUserId", "Description", "EndDate", "Name", "StartDate", "State" },
                values: new object[] { 1, null, "Project from USA", new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project1", new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "AdminUserId", "Description", "EndDate", "Name", "StartDate", "State" },
                values: new object[] { 2, null, "Project from Arg", new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project2", new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "AdminUserId", "Description", "EndDate", "Name", "StartDate", "State" },
                values: new object[] { 3, null, "Project from EU", new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project3", new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

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
                columns: new[] { "ToDoId", "EndDate", "Name", "ProjectRelatedID", "StartDate", "State", "UserID" },
                values: new object[] { 1, new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Controlers", 1, new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1 });

            migrationBuilder.InsertData(
                table: "ToDo",
                columns: new[] { "ToDoId", "EndDate", "Name", "ProjectRelatedID", "StartDate", "State", "UserID" },
                values: new object[] { 2, new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Entities", 2, new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2 });

            migrationBuilder.InsertData(
                table: "ToDo",
                columns: new[] { "ToDoId", "EndDate", "Name", "ProjectRelatedID", "StartDate", "State", "UserID" },
                values: new object[] { 3, new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Services", 3, new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Project_AdminUserId",
                table: "Project",
                column: "AdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_ProjectRelatedID",
                table: "ToDo",
                column: "ProjectRelatedID");

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_UserID",
                table: "ToDo",
                column: "UserID");
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
