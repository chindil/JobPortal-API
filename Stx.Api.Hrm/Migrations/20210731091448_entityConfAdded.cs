using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stx.Api.Hrm.Migrations
{
    public partial class entityConfAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HrCandidateJobStat");

            migrationBuilder.DropTable(
                name: "IPJob");

            migrationBuilder.DropTable(
                name: "IPJobCategory");

            migrationBuilder.DropTable(
                name: "IPJobStatus");

            migrationBuilder.DropTable(
                name: "IPMatter");

            migrationBuilder.DropTable(
                name: "MatterType");

            migrationBuilder.DropTable(
                name: "NiceClass");

            //migrationBuilder.DropTable(
            //    name: "QryIPReportJobs");

            //migrationBuilder.DropTable(
            //    name: "QryIPReportTMs");

            migrationBuilder.DropTable(
                name: "TMStatus");

            migrationBuilder.DropTable(
                name: "Trademark");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "HrJobSpecialty",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "HrJobSkill",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "HrJobSendout",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "HrJobOrder",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "HrJobIndustry",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "HrJobCategory",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "HrCandidateJobActivity",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateID = table.Column<int>(type: "int", nullable: false),
                    JobOrderID = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrCandidateJobActivity", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HrCandidateJobBookmark",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateID = table.Column<int>(type: "int", nullable: false),
                    JobOrderID = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrCandidateJobBookmark", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "HrJobIndustry",
                columns: new[] { "ID", "Active", "Name" },
                values: new object[,]
                {
                    { 1, true, "Accounting" },
                    { 28, true, "Self Employment" },
                    { 27, true, "Science & Technology" },
                    { 26, true, "Sales" },
                    { 25, true, "Retail & Consumer Products" },
                    { 24, true, "Real Estate & Property" },
                    { 23, true, "Mining, Resources & Energy" },
                    { 22, true, "Marketing & Communications" },
                    { 21, true, "Manufacturing, Transport & Logistics" },
                    { 20, true, "Legal" },
                    { 19, true, "Insurance & Superannuation" },
                    { 18, true, "Information & Communication Technology" },
                    { 17, true, "Human Resources & Recruitment" },
                    { 16, true, "Hospitality & Tourism" },
                    { 15, true, "Healthcare & Medical" },
                    { 14, true, "Government & Defence" },
                    { 13, true, "Farming, Animals & Conservation" },
                    { 12, true, "Engineering" },
                    { 11, true, "Education & Training" },
                    { 10, true, "Design & Architecture" },
                    { 9, true, "Consulting & Strategy" },
                    { 8, true, "Construction" },
                    { 7, true, "Community Services & Development" },
                    { 6, true, "CEO & General Management" },
                    { 5, true, "Call Centre & Customer Service" },
                    { 4, true, "Banking & Financial Services" },
                    { 3, true, "Advertising, Arts & Media" },
                    { 2, true, "Administration & Office Support" },
                    { 29, true, "Sport & Recreation" },
                    { 30, true, "Trades & Services" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HrCandidateJobActivity");

            migrationBuilder.DropTable(
                name: "HrCandidateJobBookmark");

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "HrJobIndustry",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "HrJobSpecialty",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "HrJobSkill",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "HrJobSendout",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "HrJobOrder",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "HrJobIndustry",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "HrJobCategory",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");

            migrationBuilder.CreateTable(
                name: "HrCandidateJobStat",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateID = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JobOrderID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrCandidateJobStat", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IPJob",
                columns: table => new
                {
                    DocNum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    BPAddrs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BPCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BPEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BPFax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BPName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BPPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateExpire = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateFiling = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DatePriority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateReg = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocStatus = table.Column<short>(type: "smallint", nullable: false),
                    FileNum = table.Column<int>(type: "int", nullable: false),
                    ImportRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImportedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvAmt = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: false),
                    InvDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobApplcNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobCategory = table.Column<short>(type: "smallint", nullable: true),
                    JobRef1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobRef2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobRef3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobSrcCC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobSrcDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JobSrcEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobSrcSender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatterType = table.Column<short>(type: "smallint", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PageUid = table.Column<short>(type: "smallint", nullable: false),
                    PctNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriorityDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TerminalID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPJob", x => x.DocNum);
                });

            migrationBuilder.CreateTable(
                name: "IPJobCategory",
                columns: table => new
                {
                    JobCatgID = table.Column<short>(type: "smallint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    JobCatgDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Seq = table.Column<short>(type: "smallint", nullable: true),
                    SessionID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StatusColor = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPJobCategory", x => x.JobCatgID);
                });

            migrationBuilder.CreateTable(
                name: "IPJobStatus",
                columns: table => new
                {
                    StatusID = table.Column<short>(type: "smallint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ref1Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Ref2Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Ref3Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Seq = table.Column<short>(type: "smallint", nullable: true),
                    SessionID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StatusColor = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    StatusDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPJobStatus", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "IPMatter",
                columns: table => new
                {
                    TenantID = table.Column<int>(type: "int", nullable: false),
                    MatterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillingMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyID = table.Column<short>(type: "smallint", nullable: true),
                    ContngncyRatePct = table.Column<decimal>(type: "NUMERIC(6,2)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateClosed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateFiled = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DynmBillableAmt = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    DynmPaidAmt = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    EstimatedEffort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImportRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatterDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatterFileNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatterHandler = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatterHandlerLead = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatterPriority = table.Column<byte>(type: "tinyint", nullable: false),
                    MatterStatus = table.Column<short>(type: "smallint", nullable: true),
                    MatterType = table.Column<short>(type: "smallint", nullable: false),
                    MatterValue = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OriginatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Privacy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    RateType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SrcModule = table.Column<short>(type: "smallint", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPMatter", x => new { x.TenantID, x.MatterID });
                });

            migrationBuilder.CreateTable(
                name: "MatterType",
                columns: table => new
                {
                    ModuleID = table.Column<int>(type: "int", nullable: false),
                    MatterTypeID = table.Column<short>(type: "smallint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    MatterTypeDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Seq = table.Column<short>(type: "smallint", nullable: true),
                    SessionID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatterType", x => new { x.ModuleID, x.MatterTypeID });
                });

            migrationBuilder.CreateTable(
                name: "NiceClass",
                columns: table => new
                {
                    ClassID = table.Column<short>(type: "smallint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    ClassDesc = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    ClassEdition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ClassName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ClassSubID = table.Column<short>(type: "smallint", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CreatedByScreen = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImportRef = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ImportedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModuleID = table.Column<int>(type: "int", nullable: false),
                    Seq = table.Column<short>(type: "smallint", nullable: true),
                    SessionID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NiceClass", x => x.ClassID);
                });

            migrationBuilder.CreateTable(
                name: "QryIPReportJobs",
                columns: table => new
                {
                    ApplcNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BPAddrs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BPCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BPEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BPFax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BPName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BPPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateExpire = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateFiling = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DatePriority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateReg = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocNum = table.Column<int>(type: "int", nullable: false),
                    DocStatusColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocStatusDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileNum = table.Column<int>(type: "int", nullable: true),
                    InvAmt = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    InvDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobSrcCC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobSrcDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JobSrcEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobSrcSender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatterType = table.Column<short>(type: "smallint", nullable: true),
                    MatterTypeDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PctNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriorityDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecStatus = table.Column<short>(type: "smallint", nullable: true),
                    Ref1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ref1Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ref2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ref2Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ref3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ref3Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TerminalID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "QryIPReportTMs",
                columns: table => new
                {
                    ApplcNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BPAddrs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BPCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BPEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BPFax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BPName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BPPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimingColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateExpire = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateFiling = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DatePriority = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateReg = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocNum = table.Column<int>(type: "int", nullable: false),
                    DocStatusColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocStatusDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileNum = table.Column<int>(type: "int", nullable: true),
                    GoodsNServcs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvAmt = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    InvDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobSrcCC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobSrcDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JobSrcEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobSrcSender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatterType = table.Column<short>(type: "smallint", nullable: true),
                    MatterTypeDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PctNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriorityDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecStatus = table.Column<short>(type: "smallint", nullable: true),
                    Ref1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ref1Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ref2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ref2Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ref3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ref3Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimilarSounds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TMLogoFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TMLogoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TMNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TMTranslation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TMWord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TerminalID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TMStatus",
                columns: table => new
                {
                    StatusID = table.Column<short>(type: "smallint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ref1Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Ref2Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Ref3Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Seq = table.Column<short>(type: "smallint", nullable: true),
                    SessionID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StatusColor = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    StatusDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TMStatus", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "Trademark",
                columns: table => new
                {
                    DocNum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    BPAddrs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BPCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BPEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BPFax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BPName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BPPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimingColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateExpire = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateFiling = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DatePriority = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateReg = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FileNum = table.Column<int>(type: "int", nullable: false),
                    GoodsNServcs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImportRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImportedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvAmt = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: false),
                    InvDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobSrcCC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobSrcDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JobSrcEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobSrcSender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatterType = table.Column<short>(type: "smallint", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PageUid = table.Column<short>(type: "smallint", nullable: false),
                    PriorityDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimilarSounds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TMLogoFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TMLogoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TMNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TMRef1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TMRef2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TMRef3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TMStatus = table.Column<short>(type: "smallint", nullable: false),
                    TMTranslation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TMWord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TerminalID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trademark", x => x.DocNum);
                });
        }
    }
}
