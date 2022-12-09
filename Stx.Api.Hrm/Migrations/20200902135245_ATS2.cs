using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stx.Api.Hrm.Migrations
{
    public partial class ATS2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HrEmployee_Country_CountryID",
                table: "HrEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_HrEmployee_HrJobCategory_JobCategoryID",
                table: "HrEmployee");

            migrationBuilder.DropIndex(
                name: "IX_HrEmployee_CountryID",
                table: "HrEmployee");

            migrationBuilder.DropIndex(
                name: "IX_HrEmployee_JobCategoryID",
                table: "HrEmployee");

            migrationBuilder.DropColumn(
                name: "CountryID",
                table: "HrEmployee");

            migrationBuilder.DropColumn(
                name: "JobCategoryID",
                table: "HrEmployee");

            migrationBuilder.RenameColumn(
                name: "JobCategoryId",
                table: "HrEmployee",
                newName: "JobCategoryID");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "HrEmployee",
                newName: "CountryID");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "HrEmployee",
                newName: "EmployeeID");

            migrationBuilder.AlterColumn<int>(
                name: "JobIndustryID",
                table: "HrJobCategory",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "HrJobCategory",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<short>(
                name: "CountryID",
                table: "HrEmployee",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateID",
                table: "HrCandidateExperience",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateID",
                table: "HrCandidateEducation",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateID",
                table: "HrCandidateCertificate",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Currency",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Currency",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CurrSymbolFrgn",
                table: "Currency",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Decimals",
                table: "Currency",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Denomination",
                table: "Currency",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Currency",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Currency",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RoundSys",
                table: "Currency",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Tstamp",
                table: "Currency",
                rowVersion: true,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HrCandidateExperience_CandidateID",
                table: "HrCandidateExperience",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_HrCandidateEducation_CandidateID",
                table: "HrCandidateEducation",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_HrCandidateCertificate_CandidateID",
                table: "HrCandidateCertificate",
                column: "CandidateID");

            migrationBuilder.AddForeignKey(
                name: "FK_HrCandidateCertificate_HrCandidate_CandidateID",
                table: "HrCandidateCertificate",
                column: "CandidateID",
                principalTable: "HrCandidate",
                principalColumn: "CandidateID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HrCandidateEducation_HrCandidate_CandidateID",
                table: "HrCandidateEducation",
                column: "CandidateID",
                principalTable: "HrCandidate",
                principalColumn: "CandidateID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HrCandidateExperience_HrCandidate_CandidateID",
                table: "HrCandidateExperience",
                column: "CandidateID",
                principalTable: "HrCandidate",
                principalColumn: "CandidateID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HrCandidateCertificate_HrCandidate_CandidateID",
                table: "HrCandidateCertificate");

            migrationBuilder.DropForeignKey(
                name: "FK_HrCandidateEducation_HrCandidate_CandidateID",
                table: "HrCandidateEducation");

            migrationBuilder.DropForeignKey(
                name: "FK_HrCandidateExperience_HrCandidate_CandidateID",
                table: "HrCandidateExperience");

            migrationBuilder.DropIndex(
                name: "IX_HrCandidateExperience_CandidateID",
                table: "HrCandidateExperience");

            migrationBuilder.DropIndex(
                name: "IX_HrCandidateEducation_CandidateID",
                table: "HrCandidateEducation");

            migrationBuilder.DropIndex(
                name: "IX_HrCandidateCertificate_CandidateID",
                table: "HrCandidateCertificate");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "CurrSymbolFrgn",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "Decimals",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "Denomination",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "RoundSys",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "Tstamp",
                table: "Currency");

            migrationBuilder.RenameColumn(
                name: "JobCategoryID",
                table: "HrEmployee",
                newName: "JobCategoryId");

            migrationBuilder.RenameColumn(
                name: "CountryID",
                table: "HrEmployee",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "HrEmployee",
                newName: "EmployeeId");

            migrationBuilder.AlterColumn<short>(
                name: "JobIndustryID",
                table: "HrJobCategory",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "ID",
                table: "HrJobCategory",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "HrEmployee",
                type: "int",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AddColumn<short>(
                name: "CountryID",
                table: "HrEmployee",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "JobCategoryID",
                table: "HrEmployee",
                type: "smallint",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CandidateID",
                table: "HrCandidateExperience",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateID",
                table: "HrCandidateEducation",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateID",
                table: "HrCandidateCertificate",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_CountryID",
                table: "HrEmployee",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_JobCategoryID",
                table: "HrEmployee",
                column: "JobCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmployee_Country_CountryID",
                table: "HrEmployee",
                column: "CountryID",
                principalTable: "Country",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmployee_HrJobCategory_JobCategoryID",
                table: "HrEmployee",
                column: "JobCategoryID",
                principalTable: "HrJobCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
