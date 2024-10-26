using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Server.Migrations
{
    public partial class V0001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Street1 = table.Column<string>(nullable: false),
                    Street2 = table.Column<string>(nullable: true),
                    Suburb = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    PostalCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    TypeOfUser = table.Column<int>(nullable: false),
                    FirmID = table.Column<Guid>(nullable: true),
                    CustomerID = table.Column<Guid>(nullable: true),
                    PasswordExpiryDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ISO2 = table.Column<string>(nullable: false),
                    DailingCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Day",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DayOfWeek = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Day", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FieldName = table.Column<string>(nullable: true),
                    ControlType = table.Column<string>(nullable: true),
                    Required = table.Column<bool>(nullable: false),
                    NullText = table.Column<string>(nullable: true),
                    FirmID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Field", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FirmEmailSettings",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FromAddress = table.Column<string>(nullable: true),
                    HostAddress = table.Column<string>(nullable: true),
                    UseSsl = table.Column<bool>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Port = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirmEmailSetting", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FirmMeetingSetup",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FirmID = table.Column<Guid>(nullable: false),
                    AllowMeetings = table.Column<bool>(nullable: false),
                    AllowPhysical = table.Column<bool>(nullable: false),
                    AllowElectrical = table.Column<bool>(nullable: false),
                    AllowPublicHolidays = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirmMeetingSetup", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IntroSteps",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    StepName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    ButtonText = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: false),
                    AllowSkip = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntroSteps", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Screens",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screen", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StyleVariables",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StyleVariable", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionPlans",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    MaxUsers = table.Column<int>(nullable: false),
                    MonthlyPrice = table.Column<double>(nullable: false),
                    YearlyPrice = table.Column<double>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDefaultPlan = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPlans", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlot",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlot", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    OwnerUserID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Meetings_AspNetUsers_OwnerUserID",
                        column: x => x.OwnerUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    DocumentTypeID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Documents_DocumentTypes_DocumentTypeID",
                        column: x => x.DocumentTypeID,
                        principalTable: "DocumentTypes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Firms",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FirmName = table.Column<string>(nullable: false),
                    AdminEmail = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: false),
                    RegistrationNumber = table.Column<string>(nullable: false),
                    VatNumber = table.Column<string>(nullable: true),
                    AddressID = table.Column<Guid>(nullable: true),
                    FirmEmailSettingID = table.Column<Guid>(nullable: true),
                    FirmMeetingSetupID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firm", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Firms_Address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Firms_FirmEmailSettings_FirmEmailSettingID",
                        column: x => x.FirmEmailSettingID,
                        principalTable: "FirmEmailSettings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Firms_FirmMeetingSetup_FirmMeetingSetupID",
                        column: x => x.FirmMeetingSetupID,
                        principalTable: "FirmMeetingSetup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserAvailabilities",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    DayID = table.Column<Guid>(nullable: false),
                    TimeSlotID = table.Column<Guid>(nullable: false),
                    Availability = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAvailability", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserAvailabilities_Day_DayID",
                        column: x => x.DayID,
                        principalTable: "Day",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAvailabilities_TimeSlot_TimeSlotID",
                        column: x => x.TimeSlotID,
                        principalTable: "TimeSlot",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAvailabilities_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeetingParticipants",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    MeetingID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    ApplicationUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingParticipant", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MeetingParticipants_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingParticipants_Meetings_MeetingID",
                        column: x => x.MeetingID,
                        principalTable: "Meetings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeetingTimeSlots",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    MeetingID = table.Column<Guid>(nullable: false),
                    TimeSlotID = table.Column<Guid>(nullable: false),
                    DayID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingTimeSlot", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MeetingTimeSlots_Day_DayID",
                        column: x => x.DayID,
                        principalTable: "Day",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingTimeSlots_Meetings_MeetingID",
                        column: x => x.MeetingID,
                        principalTable: "Meetings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingTimeSlots_TimeSlot_TimeSlotID",
                        column: x => x.TimeSlotID,
                        principalTable: "TimeSlot",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyIntroSteps",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FirmID = table.Column<Guid>(nullable: false),
                    IntroStepID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyIntroSteps", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CompanyIntroSteps_Firms_FirmID",
                        column: x => x.FirmID,
                        principalTable: "Firms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyIntroSteps_IntroSteps_IntroStepID",
                        column: x => x.IntroStepID,
                        principalTable: "IntroSteps",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractClauses",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    FirmID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractClauses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContractClauses_Firms_FirmID",
                        column: x => x.FirmID,
                        principalTable: "Firms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractTransactions",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    InTesting = table.Column<bool>(nullable: false),
                    Base64Background = table.Column<string>(nullable: true),
                    FirmID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractTransactions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContractTransactions_Firms_FirmID",
                        column: x => x.FirmID,
                        principalTable: "Firms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDataFields",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TypeOfField = table.Column<int>(nullable: false),
                    FieldName = table.Column<string>(nullable: true),
                    Required = table.Column<bool>(nullable: false),
                    NullText = table.Column<string>(nullable: true),
                    FirmID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDataFields", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerDataFields_Firms_FirmID",
                        column: x => x.FirmID,
                        principalTable: "Firms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    FirmID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Customers_Firms_FirmID",
                        column: x => x.FirmID,
                        principalTable: "Firms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FirmID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    HeaderImage = table.Column<string>(nullable: true),
                    FooterImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmailTemplates_Firms_FirmID",
                        column: x => x.FirmID,
                        principalTable: "Firms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FirmDocuments",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FirmID = table.Column<Guid>(nullable: false),
                    DocumentID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirmDocuments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FirmDocuments_Documents_DocumentID",
                        column: x => x.DocumentID,
                        principalTable: "Documents",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_FirmDocuments_Firms_FirmID",
                        column: x => x.FirmID,
                        principalTable: "Firms",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "NonWorkingDays",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    FirmID = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonWorkingDay", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NonWorkingDays_Firms_FirmID",
                        column: x => x.FirmID,
                        principalTable: "Firms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NonWorkingDays_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicHolidays",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    FirmID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicHoliday", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PublicHolidays_Firms_FirmID",
                        column: x => x.FirmID,
                        principalTable: "Firms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScreenFields",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ScreenID = table.Column<Guid>(nullable: false),
                    FieldID = table.Column<Guid>(nullable: false),
                    FirmID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreenField", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ScreenFields_Fields_FieldID",
                        column: x => x.FieldID,
                        principalTable: "Fields",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScreenFields_Firms_FirmID",
                        column: x => x.FirmID,
                        principalTable: "Firms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScreenFields_Screens_ScreenID",
                        column: x => x.ScreenID,
                        principalTable: "Screens",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StyleVariableValues",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    VariableID = table.Column<Guid>(nullable: false),
                    VariableValue = table.Column<string>(nullable: true),
                    FirmID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StyleVariableValue", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StyleVariableValues_Firms_FirmID",
                        column: x => x.FirmID,
                        principalTable: "Firms",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_StyleVariableValues_StyleVariables_VariableID",
                        column: x => x.VariableID,
                        principalTable: "StyleVariables",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "UserSubscriptionPlans",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    SubscriptionPlanID = table.Column<Guid>(nullable: false),
                    FirmID = table.Column<Guid>(nullable: false),
                    NrOFUsers = table.Column<int>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    AutoRenew = table.Column<bool>(nullable: false),
                    AutoRenewOnDay = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubscriptionPlans", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserSubscriptionPlans_Firms_FirmID",
                        column: x => x.FirmID,
                        principalTable: "Firms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSubscriptionPlans_SubscriptionPlans_SubscriptionPlanID",
                        column: x => x.SubscriptionPlanID,
                        principalTable: "SubscriptionPlans",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractClauseElements",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ContractClauseID = table.Column<Guid>(nullable: false),
                    ElementType = table.Column<string>(nullable: true),
                    ElementText = table.Column<string>(nullable: true),
                    ElementConfig = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractClauseElements", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContractClauseElements_ContractClauses_ContractClauseID",
                        column: x => x.ContractClauseID,
                        principalTable: "ContractClauses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractQuestions",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ContractTransactionID = table.Column<Guid>(nullable: false),
                    QuestionText = table.Column<string>(nullable: true),
                    TypeOfQuestion = table.Column<int>(nullable: false),
                    NextQuestionID = table.Column<Guid>(nullable: true),
                    IsRoot = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractQuestions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContractQuestions_ContractTransactions_ContractTransactionID",
                        column: x => x.ContractTransactionID,
                        principalTable: "ContractTransactions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractTransactionDataFields",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TypeOfField = table.Column<int>(nullable: false),
                    FieldName = table.Column<string>(nullable: true),
                    AllowMultiple = table.Column<bool>(nullable: false),
                    ContractTransactionID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractTransactionDataFields", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContractTransactionDataFields_ContractTransactions_ContractTransactionID",
                        column: x => x.ContractTransactionID,
                        principalTable: "ContractTransactions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractTransactionTemplates",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ContractTransactionID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractTransactionTemplates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContractTransactionTemplates_ContractTransactions_ContractTransactionID",
                        column: x => x.ContractTransactionID,
                        principalTable: "ContractTransactions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDataFieldValues",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CustomerDataFieldID = table.Column<Guid>(nullable: false),
                    CustomerID = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDataFieldValue", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerDataFieldValues_CustomerDataFields_CustomerDataFieldID",
                        column: x => x.CustomerDataFieldID,
                        principalTable: "CustomerDataFields",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerDataFieldValues_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CustomerDocuments",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CustomerID = table.Column<Guid>(nullable: false),
                    DocumentID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDocument", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerDocuments_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerDocuments_Documents_DocumentID",
                        column: x => x.DocumentID,
                        principalTable: "Documents",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ContractQuestionAnswers",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    QuestionID = table.Column<Guid>(nullable: false),
                    AnswerText = table.Column<string>(nullable: true),
                    NextQuestionID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractQuestionAnswers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContractQuestionAnswers_ContractQuestions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "ContractQuestions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractQuestionDataFields",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    QuestionID = table.Column<Guid>(nullable: false),
                    ContractTransactionDataFieldID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractQuestionDataField", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContractQuestionDataFields_ContractTransactionDataFields_ContractTransactionDataFieldID",
                        column: x => x.ContractTransactionDataFieldID,
                        principalTable: "ContractTransactionDataFields",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractQuestionDataFields_ContractQuestions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "ContractQuestions",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ContractTemplateElements",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ContractTransactionTemplateID = table.Column<Guid>(nullable: false),
                    ElementType = table.Column<string>(nullable: true),
                    ElementText = table.Column<string>(nullable: true),
                    ElementConfig = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractTemplateElements", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContractTemplateElements_ContractTransactionTemplates_ContractTransactionTemplateID",
                        column: x => x.ContractTransactionTemplateID,
                        principalTable: "ContractTransactionTemplates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractQuestionAnswerDataFields",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    AnswerID = table.Column<Guid>(nullable: false),
                    ContractTransactionDataFieldID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractQuestionAnswerDataField", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContractQuestionAnswerDataFields_ContractQuestionAnswers_AnswerID",
                        column: x => x.AnswerID,
                        principalTable: "ContractQuestionAnswers",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ContractQuestionAnswerDataFields_ContractTransactionDataFields_ContractTransactionDataFieldID",
                        column: x => x.ContractTransactionDataFieldID,
                        principalTable: "ContractTransactionDataFields",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyIntroSteps_FirmID",
                table: "CompanyIntroSteps",
                column: "FirmID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyIntroSteps_IntroStepID",
                table: "CompanyIntroSteps",
                column: "IntroStepID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractClauseElements_ContractClauseID",
                table: "ContractClauseElements",
                column: "ContractClauseID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractClauses_FirmID",
                table: "ContractClauses",
                column: "FirmID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractQuestionAnswerDataFields_AnswerID",
                table: "ContractQuestionAnswerDataFields",
                column: "AnswerID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractQuestionAnswerDataFields_ContractTransactionDataFieldID",
                table: "ContractQuestionAnswerDataFields",
                column: "ContractTransactionDataFieldID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractQuestionAnswers_QuestionID",
                table: "ContractQuestionAnswers",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractQuestionDataFields_ContractTransactionDataFieldID",
                table: "ContractQuestionDataFields",
                column: "ContractTransactionDataFieldID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractQuestionDataFields_QuestionID",
                table: "ContractQuestionDataFields",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractQuestions_ContractTransactionID",
                table: "ContractQuestions",
                column: "ContractTransactionID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTemplateElements_ContractTransactionTemplateID",
                table: "ContractTemplateElements",
                column: "ContractTransactionTemplateID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTransactionDataFields_ContractTransactionID",
                table: "ContractTransactionDataFields",
                column: "ContractTransactionID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTransactions_FirmID",
                table: "ContractTransactions",
                column: "FirmID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTransactionTemplates_ContractTransactionID",
                table: "ContractTransactionTemplates",
                column: "ContractTransactionID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDataFields_FirmID",
                table: "CustomerDataFields",
                column: "FirmID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDataFieldValues_CustomerDataFieldID",
                table: "CustomerDataFieldValues",
                column: "CustomerDataFieldID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDataFieldValues_CustomerID",
                table: "CustomerDataFieldValues",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDocuments_CustomerID",
                table: "CustomerDocuments",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDocuments_DocumentID",
                table: "CustomerDocuments",
                column: "DocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_FirmID",
                table: "Customers",
                column: "FirmID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentTypeID",
                table: "Documents",
                column: "DocumentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmailTemplates_FirmID",
                table: "EmailTemplates",
                column: "FirmID");

            migrationBuilder.CreateIndex(
                name: "IX_FirmDocuments_DocumentID",
                table: "FirmDocuments",
                column: "DocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_FirmDocuments_FirmID",
                table: "FirmDocuments",
                column: "FirmID");

            migrationBuilder.CreateIndex(
                name: "IX_Firms_AddressID",
                table: "Firms",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Firms_FirmEmailSettingID",
                table: "Firms",
                column: "FirmEmailSettingID",
                unique: true,
                filter: "[FirmEmailSettingID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Firms_FirmMeetingSetupID",
                table: "Firms",
                column: "FirmMeetingSetupID",
                unique: true,
                filter: "[FirmMeetingSetupID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingParticipants_ApplicationUserId",
                table: "MeetingParticipants",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingParticipants_MeetingID",
                table: "MeetingParticipants",
                column: "MeetingID");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_OwnerUserID",
                table: "Meetings",
                column: "OwnerUserID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingTimeSlots_DayID",
                table: "MeetingTimeSlots",
                column: "DayID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingTimeSlots_MeetingID",
                table: "MeetingTimeSlots",
                column: "MeetingID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingTimeSlots_TimeSlotID",
                table: "MeetingTimeSlots",
                column: "TimeSlotID");

            migrationBuilder.CreateIndex(
                name: "IX_NonWorkingDays_FirmID",
                table: "NonWorkingDays",
                column: "FirmID");

            migrationBuilder.CreateIndex(
                name: "IX_NonWorkingDays_UserID",
                table: "NonWorkingDays",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PublicHolidays_FirmID",
                table: "PublicHolidays",
                column: "FirmID");

            migrationBuilder.CreateIndex(
                name: "IX_ScreenFields_FieldID",
                table: "ScreenFields",
                column: "FieldID");

            migrationBuilder.CreateIndex(
                name: "IX_ScreenFields_FirmID",
                table: "ScreenFields",
                column: "FirmID");

            migrationBuilder.CreateIndex(
                name: "IX_ScreenFields_ScreenID",
                table: "ScreenFields",
                column: "ScreenID");

            migrationBuilder.CreateIndex(
                name: "IX_StyleVariableValues_FirmID",
                table: "StyleVariableValues",
                column: "FirmID");

            migrationBuilder.CreateIndex(
                name: "IX_StyleVariableValues_VariableID",
                table: "StyleVariableValues",
                column: "VariableID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAvailabilities_DayID",
                table: "UserAvailabilities",
                column: "DayID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAvailabilities_TimeSlotID",
                table: "UserAvailabilities",
                column: "TimeSlotID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAvailabilities_UserID",
                table: "UserAvailabilities",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubscriptionPlans_FirmID",
                table: "UserSubscriptionPlans",
                column: "FirmID");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubscriptionPlans_SubscriptionPlanID",
                table: "UserSubscriptionPlans",
                column: "SubscriptionPlanID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CompanyIntroSteps");

            migrationBuilder.DropTable(
                name: "ContractClauseElements");

            migrationBuilder.DropTable(
                name: "ContractQuestionAnswerDataFields");

            migrationBuilder.DropTable(
                name: "ContractQuestionDataFields");

            migrationBuilder.DropTable(
                name: "ContractTemplateElements");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "CustomerDataFieldValues");

            migrationBuilder.DropTable(
                name: "CustomerDocuments");

            migrationBuilder.DropTable(
                name: "EmailTemplates");

            migrationBuilder.DropTable(
                name: "FirmDocuments");

            migrationBuilder.DropTable(
                name: "MeetingParticipants");

            migrationBuilder.DropTable(
                name: "MeetingTimeSlots");

            migrationBuilder.DropTable(
                name: "NonWorkingDays");

            migrationBuilder.DropTable(
                name: "PublicHolidays");

            migrationBuilder.DropTable(
                name: "ScreenFields");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "StyleVariableValues");

            migrationBuilder.DropTable(
                name: "UserAvailabilities");

            migrationBuilder.DropTable(
                name: "UserSubscriptionPlans");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "IntroSteps");

            migrationBuilder.DropTable(
                name: "ContractClauses");

            migrationBuilder.DropTable(
                name: "ContractQuestionAnswers");

            migrationBuilder.DropTable(
                name: "ContractTransactionDataFields");

            migrationBuilder.DropTable(
                name: "ContractTransactionTemplates");

            migrationBuilder.DropTable(
                name: "CustomerDataFields");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "Screens");

            migrationBuilder.DropTable(
                name: "StyleVariables");

            migrationBuilder.DropTable(
                name: "Day");

            migrationBuilder.DropTable(
                name: "TimeSlot");

            migrationBuilder.DropTable(
                name: "SubscriptionPlans");

            migrationBuilder.DropTable(
                name: "ContractQuestions");

            migrationBuilder.DropTable(
                name: "DocumentTypes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ContractTransactions");

            migrationBuilder.DropTable(
                name: "Firms");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "FirmEmailSettings");

            migrationBuilder.DropTable(
                name: "FirmMeetingSetup");
        }
    }
}
