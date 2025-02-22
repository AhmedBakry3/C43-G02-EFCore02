using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_Session_2_EF_Core.Migrations
{
    /// <inheritdoc />
    public partial class CreateRelationShipsBetweenTablesWithFluentAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicNmae = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseDuration = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CourseName = table.Column<string>(type: "VarChar(50)", nullable: false),
                    CourseDecription = table.Column<string>(type: "VarChar(50)", nullable: false),
                    TopicCourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Topics_TopicCourseId",
                        column: x => x.TopicCourseId,
                        principalTable: "Topics",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentAddress = table.Column<string>(type: "VarChar(70)", maxLength: 70, nullable: false),
                    StudentHiringDate = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    InstructorDepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorName = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: false),
                    InstructorBouns = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    InstructorSalary = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    InstructorAddress = table.Column<string>(type: "VarChar(100)", maxLength: 100, nullable: false),
                    InstructorHourRate = table.Column<decimal>(type: "decimal(17,2)", nullable: false),
                    InstDeptID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructors_Departments_InstDeptID",
                        column: x => x.InstDeptID,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentFirstName = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: false),
                    StudentLastName = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: false),
                    StudentAddress = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    StuddntDepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Departments_StuddntDepartmentID",
                        column: x => x.StuddntDepartmentID,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TopicCourseId",
                table: "Courses",
                column: "TopicCourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_InstructorDepartmentId",
                table: "Departments",
                column: "InstructorDepartmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_InstDeptID",
                table: "Instructors",
                column: "InstDeptID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StuddntDepartmentID",
                table: "Students",
                column: "StuddntDepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instructors_InstructorDepartmentId",
                table: "Departments",
                column: "InstructorDepartmentId",
                principalTable: "Instructors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instructors_InstructorDepartmentId",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
