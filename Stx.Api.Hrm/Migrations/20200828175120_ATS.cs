using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stx.Api.Hrm.Migrations
{
    public partial class ATS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityCD = table.Column<string>(nullable: false),
                    CountryID = table.Column<short>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityCD);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    CompanyID = table.Column<short>(nullable: false),
                    DocNum = table.Column<int>(nullable: false),
                    ContactID = table.Column<int>(nullable: false),
                    ContactGroup = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    OtherNames = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Home = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Office = table.Column<string>(nullable: true),
                    LowyerType = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    DocStatus = table.Column<byte>(nullable: false),
                    Reference1 = table.Column<string>(nullable: true),
                    Reference2 = table.Column<string>(nullable: true),
                    Reference3 = table.Column<string>(nullable: true),
                    RefObject = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    ForeignName = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: true),
                    IC = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Privacy = table.Column<string>(nullable: true),
                    DynmCurrBalance = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    DynmDueBalance = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    DynmPaidAmt = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    DynmBillableAmt = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ImportRef = table.Column<string>(nullable: true),
                    SessionID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => new { x.CompanyID, x.DocNum });
                });

            migrationBuilder.CreateTable(
                name: "Corporate",
                columns: table => new
                {
                    CorporateID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorporateType = table.Column<string>(nullable: true),
                    CorporateGroup = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    LegalType = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<short>(nullable: false),
                    Nationality = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Phone2 = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Email2 = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    Reference1 = table.Column<string>(nullable: true),
                    Reference2 = table.Column<string>(nullable: true),
                    Reference3 = table.Column<string>(nullable: true),
                    RefObject = table.Column<string>(nullable: true),
                    CompanyLawyers = table.Column<string>(nullable: true),
                    CommercialRegInfo = table.Column<string>(nullable: true),
                    CommercialRegNum = table.Column<string>(nullable: true),
                    Privacy = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    ImportRef = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corporate", x => x.CorporateID);
                });

            //migrationBuilder.CreateTable(
            //    name: "Country",
            //    columns: table => new
            //    {
            //        CountryID = table.Column<short>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CountryCD = table.Column<string>(nullable: true),
            //        Name = table.Column<string>(nullable: true),
            //        CurrID = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Country", x => x.CountryID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Currency",
            //    columns: table => new
            //    {
            //        CurrCD = table.Column<string>(nullable: false),
            //        CurrSymbol = table.Column<string>(nullable: true),
            //        Name = table.Column<string>(nullable: true),
            //        Active = table.Column<bool>(nullable: true, defaultValue: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Currency", x => x.CurrCD);
            //    });

            migrationBuilder.CreateTable(
                name: "HrAtsDepartment",
                columns: table => new
                {
                    ID = table.Column<short>(nullable: false),
                    CorporateID = table.Column<int>(nullable: false),
                    RecID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrAtsDepartment", x => new { x.ID, x.CorporateID });
                });

            migrationBuilder.CreateTable(
                name: "HrCandidate",
                columns: table => new
                {
                    CandidateID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    NickName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    NamePrefix = table.Column<string>(nullable: true),
                    NameSuffix = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Phone2 = table.Column<string>(nullable: true),
                    WorkPhone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Email2 = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Fax2 = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    SecondaryAddress = table.Column<string>(nullable: true),
                    JobIndustry = table.Column<short>(nullable: true),
                    ExperienceLevel = table.Column<string>(nullable: true),
                    CurrOccupation = table.Column<string>(nullable: true),
                    CurrCompanyName = table.Column<string>(nullable: true),
                    CurrCompanyURL = table.Column<string>(nullable: true),
                    ExpectedSalary = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    ExpectedSalaryLow = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    PreferredLocations = table.Column<string>(nullable: true),
                    HighestEduLevel = table.Column<string>(nullable: true),
                    SkillSetDesc = table.Column<string>(nullable: true),
                    PrimarySkills = table.Column<string>(nullable: true),
                    SecondarySkills = table.Column<string>(nullable: true),
                    Specialties = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    TotalExperience = table.Column<int>(nullable: true),
                    MaritalStatus = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateAvailable = table.Column<DateTime>(nullable: true),
                    DateLastComment = table.Column<DateTime>(nullable: true),
                    DateLastModified = table.Column<DateTime>(nullable: true),
                    DateNextCall = table.Column<DateTime>(nullable: true),
                    TimeZoneOffsetEST = table.Column<int>(nullable: true),
                    PreferredContactModes = table.Column<string>(nullable: true),
                    JobSearchingMode = table.Column<string>(nullable: true),
                    IsMassMailOptOut = table.Column<bool>(nullable: true),
                    IsSmsOptIn = table.Column<bool>(nullable: true),
                    IsWhatsappOptIn = table.Column<bool>(nullable: true),
                    IsMessengerOptIn = table.Column<bool>(nullable: true),
                    Active = table.Column<bool>(nullable: true),
                    IsEditable = table.Column<bool>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    IsExempt = table.Column<bool>(nullable: true),
                    ExternalID = table.Column<string>(nullable: true),
                    EmploymentPreference = table.Column<string>(nullable: true),
                    CandidateSource = table.Column<string>(nullable: true),
                    Disability = table.Column<string>(nullable: true),
                    LinkedClientContact = table.Column<string>(nullable: true),
                    Owner = table.Column<string>(nullable: true),
                    OnboardingStatus = table.Column<string>(nullable: true),
                    Placements = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrCandidate", x => x.CandidateID);
                });

            migrationBuilder.CreateTable(
                name: "HrCandidateCertificate",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    CandidateID = table.Column<int>(nullable: false),
                    CertificateName = table.Column<string>(nullable: true),
                    LicenseNumber = table.Column<string>(nullable: true),
                    LicenseType = table.Column<string>(nullable: true),
                    Results = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    IssuedBy = table.Column<string>(nullable: true),
                    IssuerCountry = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    IsPending = table.Column<bool>(nullable: true),
                    FileAttachments = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: true),
                    DateCertified = table.Column<DateTime>(nullable: true),
                    DateExpiration = table.Column<DateTime>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateLastModified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrCandidateCertificate", x => new { x.ID, x.CandidateID });
                });

            migrationBuilder.CreateTable(
                name: "HrCandidateEducation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    CandidateID = table.Column<int>(nullable: false),
                    Institute = table.Column<string>(nullable: true),
                    InstituteUnit = table.Column<string>(nullable: true),
                    Country = table.Column<short>(nullable: true),
                    City = table.Column<short>(nullable: true),
                    QualificationName = table.Column<string>(nullable: true),
                    QualificationType = table.Column<string>(nullable: true),
                    FieldOfStudy = table.Column<string>(nullable: true),
                    DateGraduated = table.Column<DateTime>(nullable: false),
                    DateStarted = table.Column<DateTime>(nullable: false),
                    DateExpiration = table.Column<DateTime>(nullable: false),
                    Field = table.Column<string>(nullable: true),
                    Major = table.Column<string>(nullable: true),
                    Grade = table.Column<string>(nullable: true),
                    Gpa = table.Column<double>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrCandidateEducation", x => new { x.ID, x.CandidateID });
                });

            migrationBuilder.CreateTable(
                name: "HrCandidateExperience",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    CandidateID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    CorporateID = table.Column<int>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    DateStart = table.Column<DateTime>(nullable: true),
                    DateEnd = table.Column<DateTime>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsCurrentJob = table.Column<bool>(nullable: false),
                    Active = table.Column<bool>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    Salary = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    SalaryCycle = table.Column<string>(nullable: true),
                    Bonus = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    Commission = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    JobOrderID = table.Column<int>(nullable: true),
                    PlacementID = table.Column<int>(nullable: true),
                    TerminationReason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrCandidateExperience", x => new { x.ID, x.CandidateID });
                });

            migrationBuilder.CreateTable(
                name: "HrJobCategory",
                columns: table => new
                {
                    ID = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobIndustryID = table.Column<short>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrJobCategory", x => x.ID);
                });

            //migrationBuilder.CreateTable(
            //    name: "IPJob",
            //    columns: table => new
            //    {
            //        DocNum = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FileNum = table.Column<int>(nullable: false),
            //        JobCategory = table.Column<short>(nullable: true),
            //        MatterType = table.Column<short>(nullable: false),
            //        JobApplcNum = table.Column<string>(nullable: true),
            //        JobTitle = table.Column<string>(nullable: true),
            //        PctNum = table.Column<string>(nullable: true),
            //        DocStatus = table.Column<short>(nullable: false),
            //        PriorityDetail = table.Column<string>(nullable: true),
            //        DatePriority = table.Column<string>(nullable: true),
            //        DateFiling = table.Column<DateTime>(nullable: true),
            //        DateReg = table.Column<DateTime>(nullable: true),
            //        DateExpire = table.Column<DateTime>(nullable: true),
            //        JobSrcSender = table.Column<string>(nullable: true),
            //        JobSrcEmail = table.Column<string>(nullable: true),
            //        JobSrcCC = table.Column<string>(nullable: true),
            //        JobSrcDate = table.Column<DateTime>(nullable: true),
            //        InvNum = table.Column<string>(nullable: true),
            //        InvDate = table.Column<DateTime>(nullable: true),
            //        InvAmt = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: false),
            //        JobRef1 = table.Column<string>(nullable: true),
            //        JobRef2 = table.Column<string>(nullable: true),
            //        JobRef3 = table.Column<string>(nullable: true),
            //        BPCode = table.Column<string>(nullable: true),
            //        BPName = table.Column<string>(nullable: true),
            //        BPAddrs = table.Column<string>(nullable: true),
            //        BPEmail = table.Column<string>(nullable: true),
            //        BPPhone = table.Column<string>(nullable: true),
            //        BPFax = table.Column<string>(nullable: true),
            //        Active = table.Column<bool>(nullable: false),
            //        PageUid = table.Column<short>(nullable: false),
            //        TerminalID = table.Column<string>(nullable: true),
            //        CreatedOn = table.Column<DateTime>(nullable: true),
            //        CreatedBy = table.Column<string>(nullable: true),
            //        ModifiedOn = table.Column<DateTime>(nullable: true),
            //        ModifiedBy = table.Column<string>(nullable: true),
            //        ImportedOn = table.Column<DateTime>(nullable: true),
            //        ImportRef = table.Column<string>(nullable: true),
            //        SessionID = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_IPJob", x => x.DocNum);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "IPJobCategory",
            //    columns: table => new
            //    {
            //        JobCatgID = table.Column<short>(nullable: false),
            //        JobCatgDesc = table.Column<string>(maxLength: 50, nullable: true),
            //        Active = table.Column<bool>(nullable: false),
            //        Seq = table.Column<short>(nullable: true),
            //        SessionID = table.Column<string>(maxLength: 50, nullable: true),
            //        ModifiedBy = table.Column<string>(maxLength: 30, nullable: true),
            //        ModifiedOn = table.Column<DateTime>(nullable: true),
            //        StatusColor = table.Column<string>(maxLength: 10, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_IPJobCategory", x => x.JobCatgID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "IPJobStatus",
            //    columns: table => new
            //    {
            //        StatusID = table.Column<short>(nullable: false),
            //        StatusDesc = table.Column<string>(maxLength: 50, nullable: true),
            //        Ref1Title = table.Column<string>(maxLength: 30, nullable: true),
            //        Ref2Title = table.Column<string>(maxLength: 30, nullable: true),
            //        Ref3Title = table.Column<string>(maxLength: 30, nullable: true),
            //        Seq = table.Column<short>(nullable: true),
            //        Active = table.Column<bool>(nullable: true),
            //        SessionID = table.Column<string>(maxLength: 50, nullable: true),
            //        ModifiedBy = table.Column<string>(maxLength: 30, nullable: true),
            //        ModifiedOn = table.Column<DateTime>(nullable: true),
            //        StatusColor = table.Column<string>(maxLength: 10, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_IPJobStatus", x => x.StatusID);
            //    });

            migrationBuilder.CreateTable(
                name: "Lang",
                columns: table => new
                {
                    LangID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: true, defaultValue: true),
                    HasWrittenLang = table.Column<bool>(nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lang", x => x.LangID);
                });

            //migrationBuilder.CreateTable(
            //    name: "Matter",
            //    columns: table => new
            //    {
            //        CompanyID = table.Column<short>(nullable: false),
            //        DocNum = table.Column<int>(nullable: false),
            //        MatterName = table.Column<string>(nullable: true),
            //        MatterDesc = table.Column<string>(nullable: true),
            //        MatterType = table.Column<string>(nullable: true),
            //        ClientID = table.Column<string>(nullable: true),
            //        ClientName = table.Column<string>(nullable: true),
            //        RequestedBy = table.Column<string>(nullable: true),
            //        OriginatedBy = table.Column<string>(nullable: true),
            //        AssignedBy = table.Column<string>(nullable: true),
            //        AssignedTo = table.Column<string>(nullable: true),
            //        DateReceived = table.Column<string>(nullable: true),
            //        DateFiled = table.Column<string>(nullable: true),
            //        DateDue = table.Column<string>(nullable: true),
            //        DateClosed = table.Column<DateTime>(nullable: false),
            //        DocStatus = table.Column<byte>(nullable: false),
            //        MatterFileNum = table.Column<string>(nullable: true),
            //        MatterPriority = table.Column<byte>(nullable: false),
            //        MatterStatus = table.Column<string>(nullable: true),
            //        MatterValue = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: false),
            //        EstimatedEffort = table.Column<string>(nullable: true),
            //        Privacy = table.Column<string>(nullable: true),
            //        RateType = table.Column<string>(nullable: true),
            //        Rate = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: false),
            //        ContngncyRatePct = table.Column<decimal>(type: "NUMERIC(6,2)", nullable: false),
            //        DynmPaidAmt = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: false),
            //        DynmBillableAmt = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: false),
            //        CaseNumber = table.Column<string>(nullable: true),
            //        BillingMethod = table.Column<string>(nullable: true),
            //        MatterHandlerLead = table.Column<string>(nullable: true),
            //        MatterHandler = table.Column<string>(nullable: true),
            //        ModuleID = table.Column<short>(nullable: false),
            //        CreatedByModule = table.Column<short>(nullable: false),
            //        CreatedOn = table.Column<DateTime>(nullable: false),
            //        CreatedBy = table.Column<string>(nullable: true),
            //        ModifiedOn = table.Column<DateTime>(nullable: false),
            //        ModifiedBy = table.Column<string>(nullable: true),
            //        ImportRef = table.Column<string>(nullable: true),
            //        SessionID = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Matter", x => new { x.CompanyID, x.DocNum });
            //    });

            //migrationBuilder.CreateTable(
            //    name: "MatterType",
            //    columns: table => new
            //    {
            //        ModuleID = table.Column<int>(nullable: false),
            //        MatterTypeID = table.Column<short>(nullable: false),
            //        MatterTypeDesc = table.Column<string>(maxLength: 50, nullable: true),
            //        Seq = table.Column<short>(nullable: true),
            //        Active = table.Column<bool>(nullable: true),
            //        SessionID = table.Column<string>(maxLength: 50, nullable: true),
            //        ModifiedBy = table.Column<string>(maxLength: 30, nullable: true),
            //        ModifiedOn = table.Column<DateTime>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MatterType", x => new { x.ModuleID, x.MatterTypeID });
            //    });

            migrationBuilder.CreateTable(
                name: "Nationality",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    CountryId = table.Column<short>(nullable: false),
                    Active = table.Column<bool>(nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationality", x => x.ID);
                });

            //migrationBuilder.CreateTable(
            //    name: "NiceClass",
            //    columns: table => new
            //    {
            //        ClassID = table.Column<short>(nullable: false),
            //        ClassSubID = table.Column<short>(nullable: true),
            //        ClassName = table.Column<string>(maxLength: 50, nullable: true),
            //        ClassDesc = table.Column<string>(maxLength: 4000, nullable: true),
            //        ClassEdition = table.Column<string>(maxLength: 50, nullable: true),
            //        ModuleID = table.Column<int>(nullable: false),
            //        CreatedByScreen = table.Column<string>(maxLength: 30, nullable: true),
            //        CreatedBy = table.Column<string>(maxLength: 30, nullable: true),
            //        CreatedOn = table.Column<DateTime>(nullable: true),
            //        ModifiedBy = table.Column<string>(maxLength: 30, nullable: true),
            //        ModifiedOn = table.Column<DateTime>(nullable: true),
            //        ImportRef = table.Column<string>(maxLength: 20, nullable: true),
            //        ImportedOn = table.Column<DateTime>(nullable: true),
            //        Seq = table.Column<short>(nullable: true),
            //        Active = table.Column<bool>(nullable: true),
            //        SessionID = table.Column<string>(maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_NiceClass", x => x.ClassID);
            //    });

            migrationBuilder.CreateTable(
                name: "QryIPReportJobs",
                columns: table => new
                {
                    DocNum = table.Column<int>(nullable: false),
                    FileNum = table.Column<int>(nullable: true),
                    MatterType = table.Column<short>(nullable: true),
                    ApplcNum = table.Column<string>(nullable: true),
                    Desc = table.Column<string>(nullable: true),
                    PctNum = table.Column<string>(nullable: true),
                    RecStatus = table.Column<short>(nullable: true),
                    PriorityDetail = table.Column<string>(nullable: true),
                    DatePriority = table.Column<string>(nullable: true),
                    DateFiling = table.Column<DateTime>(nullable: true),
                    DateReg = table.Column<DateTime>(nullable: true),
                    DateExpire = table.Column<DateTime>(nullable: true),
                    BPCode = table.Column<string>(nullable: true),
                    BPName = table.Column<string>(nullable: true),
                    BPAddrs = table.Column<string>(nullable: true),
                    BPEmail = table.Column<string>(nullable: true),
                    BPPhone = table.Column<string>(nullable: true),
                    BPFax = table.Column<string>(nullable: true),
                    JobSrcSender = table.Column<string>(nullable: true),
                    JobSrcEmail = table.Column<string>(nullable: true),
                    JobSrcCC = table.Column<string>(nullable: true),
                    JobSrcDate = table.Column<DateTime>(nullable: true),
                    InvNum = table.Column<string>(nullable: true),
                    InvDate = table.Column<DateTime>(nullable: true),
                    InvAmt = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    Ref1 = table.Column<string>(nullable: true),
                    Ref2 = table.Column<string>(nullable: true),
                    Ref3 = table.Column<string>(nullable: true),
                    DocStatusDesc = table.Column<string>(nullable: true),
                    DocStatusColor = table.Column<string>(nullable: true),
                    MatterTypeDesc = table.Column<string>(nullable: true),
                    Ref1Title = table.Column<string>(nullable: true),
                    Ref2Title = table.Column<string>(nullable: true),
                    Ref3Title = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    TerminalID = table.Column<string>(nullable: true),
                    SessionID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });


            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    StateID = table.Column<short>(nullable: false),
                    CountryID = table.Column<short>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => new { x.StateID, x.CountryID });
                });

            //migrationBuilder.CreateTable(
            //    name: "Trademark",
            //    columns: table => new
            //    {
            //        DocNum = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FileNum = table.Column<int>(nullable: false),
            //        TMNum = table.Column<string>(nullable: true),
            //        TMWord = table.Column<string>(nullable: true),
            //        TMLogoName = table.Column<string>(nullable: true),
            //        TMLogoFile = table.Column<string>(nullable: true),
            //        ClassID = table.Column<string>(nullable: true),
            //        TMStatus = table.Column<short>(nullable: false),
            //        TMTranslation = table.Column<string>(nullable: true),
            //        ClaimingColor = table.Column<string>(nullable: true),
            //        GoodsNServcs = table.Column<string>(nullable: true),
            //        MatterType = table.Column<short>(nullable: false),
            //        SimilarSounds = table.Column<string>(nullable: true),
            //        BPCode = table.Column<string>(nullable: true),
            //        BPName = table.Column<string>(nullable: true),
            //        BPAddrs = table.Column<string>(nullable: true),
            //        BPPhone = table.Column<string>(nullable: true),
            //        BPEmail = table.Column<string>(nullable: true),
            //        BPFax = table.Column<string>(nullable: true),
            //        DateFiling = table.Column<DateTime>(nullable: true),
            //        DateReg = table.Column<DateTime>(nullable: true),
            //        DateExpire = table.Column<DateTime>(nullable: true),
            //        DatePriority = table.Column<DateTime>(nullable: true),
            //        PriorityDetail = table.Column<string>(nullable: true),
            //        TMRef1 = table.Column<string>(nullable: true),
            //        TMRef2 = table.Column<string>(nullable: true),
            //        TMRef3 = table.Column<string>(nullable: true),
            //        JobSrcSender = table.Column<string>(nullable: true),
            //        JobSrcEmail = table.Column<string>(nullable: true),
            //        JobSrcCC = table.Column<string>(nullable: true),
            //        JobSrcDate = table.Column<DateTime>(nullable: true),
            //        InvNum = table.Column<string>(nullable: true),
            //        InvDate = table.Column<DateTime>(nullable: true),
            //        InvAmt = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: false),
            //        Active = table.Column<bool>(nullable: false),
            //        PageUid = table.Column<short>(nullable: false),
            //        TerminalID = table.Column<string>(nullable: true),
            //        CreatedOn = table.Column<DateTime>(nullable: true),
            //        CreatedBy = table.Column<string>(nullable: true),
            //        ModifiedOn = table.Column<DateTime>(nullable: true),
            //        ModifiedBy = table.Column<string>(nullable: true),
            //        ImportedOn = table.Column<DateTime>(nullable: true),
            //        ImportRef = table.Column<string>(nullable: true),
            //        SessionID = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Trademark", x => x.DocNum);
            //    });

            migrationBuilder.CreateTable(
                name: "HrEmployee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CountryID = table.Column<short>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Smoker = table.Column<bool>(nullable: false),
                    MaritalStatus = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    JoinedDate = table.Column<DateTime>(nullable: true),
                    ExitDate = table.Column<DateTime>(nullable: true),
                    JobCategoryId = table.Column<int>(nullable: false),
                    //JobCategoryID = table.Column<short>(nullable: true),
                    Latitude = table.Column<double>(nullable: true),
                    Longitude = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrEmployee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_HrEmployee_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Restrict);
                    //table.ForeignKey(
                    //    name: "FK_HrEmployee_HrJobCategory_JobCategoryID",
                    //    column: x => x.JobCategoryId,
                    //    principalTable: "HrJobCategory",
                    //    principalColumn: "ID",
                    //    onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_CountryID",
                table: "HrEmployee",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_JobCategoryID",
                table: "HrEmployee",
                column: "JobCategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Corporate");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "HrAtsDepartment");

            migrationBuilder.DropTable(
                name: "HrCandidate");

            migrationBuilder.DropTable(
                name: "HrCandidateCertificate");

            migrationBuilder.DropTable(
                name: "HrCandidateEducation");

            migrationBuilder.DropTable(
                name: "HrCandidateExperience");

            migrationBuilder.DropTable(
                name: "HrEmployee");

            migrationBuilder.DropTable(
                name: "IPJob");

            migrationBuilder.DropTable(
                name: "IPJobCategory");

            migrationBuilder.DropTable(
                name: "IPJobStatus");

            migrationBuilder.DropTable(
                name: "Lang");

            migrationBuilder.DropTable(
                name: "Matter");

            migrationBuilder.DropTable(
                name: "MatterType");

            migrationBuilder.DropTable(
                name: "Nationality");

            migrationBuilder.DropTable(
                name: "NiceClass");

            migrationBuilder.DropTable(
                name: "QryIPReportJobs");

            migrationBuilder.DropTable(
                name: "QryIPReportTMs");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "TMStatus");

            migrationBuilder.DropTable(
                name: "Trademark");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "HrJobCategory");

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "JobCategories",
                columns: table => new
                {
                    JobCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategories", x => x.JobCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExitDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    JobCategoryId = table.Column<int>(type: "int", nullable: false),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Smoker = table.Column<bool>(type: "bit", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_JobCategories_JobCategoryId",
                        column: x => x.JobCategoryId,
                        principalTable: "JobCategories",
                        principalColumn: "JobCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, "Belgium" },
                    { 8, "France" },
                    { 7, "UK" },
                    { 6, "China" },
                    { 9, "Brazil" },
                    { 4, "USA" },
                    { 3, "Netherlands" },
                    { 2, "Germany" },
                    { 5, "Japan" }
                });

            migrationBuilder.InsertData(
                table: "JobCategories",
                columns: new[] { "JobCategoryId", "JobCategoryName" },
                values: new object[,]
                {
                    { 8, "Cleaning" },
                    { 1, "Pie research" },
                    { 2, "Sales" },
                    { 3, "Management" },
                    { 4, "Store staff" },
                    { 5, "Finance" },
                    { 6, "QA" },
                    { 7, "IT" },
                    { 9, "Bakery" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "BirthDate", "City", "Comment", "CountryId", "Email", "ExitDate", "FirstName", "Gender", "JobCategoryId", "JoinedDate", "LastName", "MaritalStatus", "PhoneNumber", "Smoker", "Street", "Zip" },
                values: new object[] { 1, new DateTime(1979, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brussels", "Lorem Ipsum", 1, "bethany@bethanyspieshop.com", null, "Bethany", 1, 1, new DateTime(2015, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", 1, "324777888773", false, "Grote Markt 1", "1000" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CountryId",
                table: "Employees",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobCategoryId",
                table: "Employees",
                column: "JobCategoryId");
        }
    }
}
