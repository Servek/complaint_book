using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ComplaintBook.Migrations
{
    public partial class UpdateGradeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Employees_EmployeeId",
                table: "Grades");

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "Grades",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Grades",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ReportType",
                table: "Grades",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Grades",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Grades",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderEmail",
                table: "Grades",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderName",
                table: "Grades",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Employees_EmployeeId",
                table: "Grades",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Employees_EmployeeId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "ReportType",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "SenderEmail",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "SenderName",
                table: "Grades");

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "Grades",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Grades",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Employees_EmployeeId",
                table: "Grades",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
