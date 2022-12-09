using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stx.Api.Hrm.Migrations
{
    public partial class Nov211 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "HrAtsDepartment");

            migrationBuilder.DropColumn(
                name: "RecID",
                table: "HrAtsDepartment");

            migrationBuilder.DropColumn(
                name: "AddedByUser",
                table: "Corporate");

            migrationBuilder.DropColumn(
                name: "ModifiedByUser",
                table: "Corporate");

            migrationBuilder.AlterColumn<short>(
                name: "CountryID",
                table: "HrJobCandidate",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<short>(
                name: "CountryID",
                table: "HrCandidate",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HrAtsDepartment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "HrAtsDepartment",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "HrAtsDepartment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateLastModified",
                table: "HrAtsDepartment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "DepartmentID",
                table: "HrAtsDepartment",
                type: "smallint",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdded",
                table: "HrAtsDepartment",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserModified",
                table: "HrAtsDepartment",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdded",
                table: "Corporate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserModified",
                table: "Corporate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HrAtsMailTemplate",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorporateID = table.Column<int>(type: "int", nullable: false),
                    JobOrderID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", maxLength: 9000, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    UserAdded = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModified = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrAtsMailTemplate", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HrAtsTeam",
                columns: table => new
                {
                    CorporateID = table.Column<int>(type: "int", nullable: false),
                    CorpUserID = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UserAdded = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModified = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsReqAccepted = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrAtsTeam", x => new { x.CorporateID, x.CorpUserID });
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    NamePrefix = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    NameSuffix = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    WorkPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Email2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fax2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CountryID = table.Column<short>(type: "smallint", nullable: true),
                    Nationality = table.Column<short>(type: "smallint", nullable: true),
                    SecondaryAddress = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeZoneOffsetEST = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", maxLength: 50, nullable: true),
                    IsEditable = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    IsRegistered = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    IsCandidate = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    IsCorporateUser = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Privacy = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.UserName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HrAtsMailTemplate");

            migrationBuilder.DropTable(
                name: "HrAtsTeam");

            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "HrAtsDepartment");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                table: "HrAtsDepartment");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "HrAtsDepartment");

            migrationBuilder.DropColumn(
                name: "UserAdded",
                table: "HrAtsDepartment");

            migrationBuilder.DropColumn(
                name: "UserModified",
                table: "HrAtsDepartment");

            migrationBuilder.DropColumn(
                name: "UserAdded",
                table: "Corporate");

            migrationBuilder.DropColumn(
                name: "UserModified",
                table: "Corporate");

            migrationBuilder.AlterColumn<short>(
                name: "CountryID",
                table: "HrJobCandidate",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "CountryID",
                table: "HrCandidate",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HrAtsDepartment",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "ID",
                table: "HrAtsDepartment",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "HrAtsDepartment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RecID",
                table: "HrAtsDepartment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AddedByUser",
                table: "Corporate",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUser",
                table: "Corporate",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }
    }
}
