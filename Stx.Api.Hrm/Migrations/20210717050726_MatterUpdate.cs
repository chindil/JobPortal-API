using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stx.Api.Hrm.Migrations
{
    public partial class MatterUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matter");

            migrationBuilder.CreateTable(
                name: "IPMatter",
                columns: table => new
                {
                    TenantID = table.Column<int>(type: "int", nullable: false),
                    MatterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID = table.Column<short>(type: "smallint", nullable: false),
                    MatterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatterDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatterType = table.Column<short>(type: "smallint", nullable: false),
                    ClientID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateFiled = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateClosed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    MatterPriority = table.Column<byte>(type: "tinyint", nullable: false),
                    MatterFileNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatterStatus = table.Column<short>(type: "smallint", nullable: true),
                    MatterValue = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: false),
                    EstimatedEffort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Privacy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RateType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: false),
                    ContngncyRatePct = table.Column<decimal>(type: "NUMERIC(6,2)", nullable: false),
                    DynmPaidAmt = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: false),
                    DynmBillableAmt = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: false),
                    CaseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillingMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatterHandler = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatterHandlerLead = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SrcModule = table.Column<short>(type: "smallint", nullable: true),
                    ImportRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SessionID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPMatter", x => new { x.TenantID, x.MatterID });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IPMatter");

            migrationBuilder.CreateTable(
                name: "Matter",
                columns: table => new
                {
                    CompanyID = table.Column<short>(type: "smallint", nullable: false),
                    DocNum = table.Column<int>(type: "int", nullable: false),
                    AssignedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillingMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContngncyRatePct = table.Column<decimal>(type: "NUMERIC(6,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByModule = table.Column<short>(type: "smallint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateClosed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateFiled = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateReceived = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    DynmBillableAmt = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: false),
                    DynmPaidAmt = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: false),
                    EstimatedEffort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImportRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatterDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatterFileNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatterHandler = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatterHandlerLead = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatterPriority = table.Column<byte>(type: "tinyint", nullable: false),
                    MatterStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatterType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatterValue = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModuleID = table.Column<short>(type: "smallint", nullable: false),
                    OriginatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Privacy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: false),
                    RateType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matter", x => new { x.CompanyID, x.DocNum });
                });
        }
    }
}
