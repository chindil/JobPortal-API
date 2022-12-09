using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stx.Api.Hrm.Migrations
{
    public partial class CandidateMultiData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HrCandidateMultiData",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateID = table.Column<int>(type: "int", nullable: false),
                    RecordType = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntityValue = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntityDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrCandidateMultiData", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HrCandidateMultiData_CandidateID_RecordType_EntityValue",
                table: "HrCandidateMultiData",
                columns: new[] { "CandidateID", "RecordType", "EntityValue" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HrCandidateMultiData");
        }
    }
}
