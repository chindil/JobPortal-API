using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stx.Api.Hrm.Migrations
{
    public partial class ATS6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CorporateID",
                table: "HrJobOrder",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "HrJobOrder",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplyByEmail",
                table: "HrJobOrder",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplyByMobileNum",
                table: "HrJobOrder",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "HrJobOrder",
                type: "NUMERIC(9,6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "HrJobOrder",
                type: "NUMERIC(9,6)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HrJobSendout",
                columns: table => new
                {
                    CandidateID = table.Column<int>(nullable: false),
                    JobOrderID = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false),
                    CorporateID = table.Column<int>(nullable: false),
                    CorporateContact = table.Column<string>(maxLength: 100, nullable: true),
                    CorporateEmail = table.Column<string>(maxLength: 100, nullable: true),
                    IsEmailSent = table.Column<bool>(nullable: false),
                    IsRead = table.Column<bool>(nullable: false),
                    Sender = table.Column<string>(maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false, defaultValue: true),
                    Status = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrJobSendout", x => new { x.CandidateID, x.JobOrderID });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HrJobSendout");

            migrationBuilder.DropColumn(
                name: "ApplyByEmail",
                table: "HrJobOrder");

            migrationBuilder.DropColumn(
                name: "ApplyByMobileNum",
                table: "HrJobOrder");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "HrJobOrder");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "HrJobOrder");

            migrationBuilder.AlterColumn<int>(
                name: "CorporateID",
                table: "HrJobOrder",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "HrJobOrder",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValue: true);
        }
    }
}
