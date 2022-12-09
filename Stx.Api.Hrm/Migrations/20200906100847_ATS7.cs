using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stx.Api.Hrm.Migrations
{
    public partial class ATS7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HrJobSendout",
                table: "HrJobSendout");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "HrCandidate");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Corporate");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Corporate");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Corporate");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Corporate");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "HrJobSendout",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "HrJobSendout",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "JobHoursPerWeek",
                table: "HrJobOrder",
                type: "NUMERIC(6,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(19,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "HrCandidate",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(800)",
                oldMaxLength: 800,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "HrCandidate",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "HrCandidate",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Corporate",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddedByUser",
                table: "Corporate",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "Corporate",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Corporate",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateLastModified",
                table: "Corporate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUser",
                table: "Corporate",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HrJobSendout",
                table: "HrJobSendout",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HrJobSendout",
                table: "HrJobSendout");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "HrCandidate");

            migrationBuilder.DropColumn(
                name: "City",
                table: "HrCandidate");

            migrationBuilder.DropColumn(
                name: "AddedByUser",
                table: "Corporate");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "Corporate");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Corporate");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                table: "Corporate");

            migrationBuilder.DropColumn(
                name: "ModifiedByUser",
                table: "Corporate");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "HrJobSendout",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "HrJobSendout",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "JobHoursPerWeek",
                table: "HrJobOrder",
                type: "NUMERIC(19,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(6,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "HrCandidate",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "HrCandidate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Corporate",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Corporate",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Corporate",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Corporate",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Corporate",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HrJobSendout",
                table: "HrJobSendout",
                columns: new[] { "CandidateID", "JobOrderID" });
        }
    }
}
