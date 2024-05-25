using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RoboticsLabManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "skygreen");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                schema: "skygreen",
                columns: table => new
                {
                    BlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogId);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                schema: "skygreen",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "skygreen",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpenTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CloseTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                schema: "skygreen",
                columns: table => new
                {
                    EquipmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.EquipmentID);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentLogs",
                schema: "skygreen",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approval = table.Column<int>(type: "int", nullable: false),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeaturedContents",
                schema: "skygreen",
                columns: table => new
                {
                    ContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullContentLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeaturedContents", x => x.ContentId);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                schema: "skygreen",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Holidays",
                schema: "skygreen",
                columns: table => new
                {
                    HolidayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.HolidayId);
                });

            migrationBuilder.CreateTable(
                name: "Researches",
                schema: "skygreen",
                columns: table => new
                {
                    ResearchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Authors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullTextLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Researches", x => x.ResearchId);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                schema: "skygreen",
                columns: table => new
                {
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Thresholds",
                schema: "skygreen",
                columns: table => new
                {
                    ThresholdId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LowStockThreshold = table.Column<int>(type: "int", nullable: false),
                    NotificationMethod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thresholds", x => x.ThresholdId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "skygreen",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Session = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoinDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Branch",
                schema: "skygreen",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branch_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "skygreen",
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                schema: "skygreen",
                columns: table => new
                {
                    PurchaseOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.PurchaseOrderId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalSchema: "skygreen",
                        principalTable: "Equipment",
                        principalColumn: "EquipmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentLogItems",
                schema: "skygreen",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    EquipmentLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentLogItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentLogItems_EquipmentLogs_EquipmentLogId",
                        column: x => x.EquipmentLogId,
                        principalSchema: "skygreen",
                        principalTable: "EquipmentLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                schema: "skygreen",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalSchema: "skygreen",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_Users_SenderId",
                        column: x => x.SenderId,
                        principalSchema: "skygreen",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResearchResults",
                schema: "skygreen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Introduction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abstract = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Methodology = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Conclusion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearchResults_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "skygreen",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("17fa016f-ae8b-4044-80e3-abd54dfe392f"), 0, "9cc5354d-1b0e-4035-a2de-238b77b71a1b", "admin@gmail.com", true, true, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEKrT8QYmG0/wchc1aiKF4+yKoVqv5pXEIFrXhQIfW0S/szQhoEYpWoJsMLPE+xuzcw==", "1234567890", false, "BFCC7B453A8B4B6C8A4C93EE28A3B4A8", false, "admin" },
                    { new Guid("8fd9fc20-5382-4f44-88fd-c78993a1d8e5"), 0, "b7d8a211-9c70-45ea-b9a7-27c5e453ecc1", "Teacher@gmail.com", true, true, null, "Teacher@GMAIL.COM", "Teacher", "AQAAAAIAAYagAAAAELcAOYUwbR7OUfAo0COYVDbv70YP+SjkVOw75SHsGggfzU5NK+yqgSdWYjQh8Gm9CQ==", "1234567890", false, "FC37C84E276C4D978DF9054129D0CB23", false, "Teacher" }
                });

            migrationBuilder.InsertData(
                schema: "skygreen",
                table: "Blogs",
                columns: new[] { "BlogId", "Author", "Content", "PublicationDate", "ThumbnailImage", "Title" },
                values: new object[,]
                {
                    { new Guid("3f1e62c7-8635-4952-97ec-ce94c4927e32"), "Bob Williams", "Content of the blog post 2", new DateTime(2024, 5, 25, 23, 28, 50, 84, DateTimeKind.Local).AddTicks(7229), "https://images.unsplash.com/photo-1667489022797-ab608913feeb?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHw5fHx8ZW58MHx8fHw%3D&auto=format&fit=crop&w=800&q=60", "Sample Blog Title 2" },
                    { new Guid("4e602d71-dc4a-46ae-8b23-43a47e169424"), "Alice Johnson", "Content of the blog post 1", new DateTime(2024, 5, 25, 23, 28, 50, 84, DateTimeKind.Local).AddTicks(7224), "https://images.unsplash.com/photo-1667489022797-ab608913feeb?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHw5fHx8ZW58MHx8fHw%3D&auto=format&fit=crop&w=800&q=60", "Sample Blog Title 1" }
                });

            migrationBuilder.InsertData(
                schema: "skygreen",
                table: "Company",
                columns: new[] { "Id", "Address", "CloseTime", "Email", "LogoUrl", "Name", "OpenTime", "Phone", "Website" },
                values: new object[] { new Guid("f00918a5-3a59-4e3c-9a47-cf36930e7add"), "Pentti Kaiteran katu 1, 90570 Oulu, Finland", new TimeSpan(0, 20, 0, 0, 0), "info@OuluUniversity.com", null, "Oulu University of Applied Sciences", new TimeSpan(0, 10, 0, 0, 0), "+358 29 4480000", "https://www.oulu.fi/en" });

            migrationBuilder.InsertData(
                schema: "skygreen",
                table: "FeaturedContents",
                columns: new[] { "ContentId", "Author", "ContentType", "FullContentLink", "PublicationDate", "Summary", "ThumbnailImage", "Title" },
                values: new object[,]
                {
                    { new Guid("84559f7a-e284-429f-a638-ba8de856b260"), "Eva Brown", "Blog", "http://example.com/featured1", new DateTime(2024, 5, 25, 23, 28, 50, 84, DateTimeKind.Local).AddTicks(7302), "Summary of the featured content 1", "https://images.unsplash.com/photo-1667489022797-ab608913feeb?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHw5fHx8ZW58MHx8fHw%3D&auto=format&fit=crop&w=800&q=60", "Sample Featured Content Title 1" },
                    { new Guid("b092d25a-6377-42cd-907c-81f07c3c3f6a"), "David Miller", "Research", "http://example.com/featured2", new DateTime(2024, 5, 25, 23, 28, 50, 84, DateTimeKind.Local).AddTicks(7307), "Summary of the featured content 2", "https://images.unsplash.com/photo-1667489022797-ab608913feeb?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHw5fHx8ZW58MHx8fHw%3D&auto=format&fit=crop&w=800&q=60", "Sample Featured Content Title 2" }
                });

            migrationBuilder.InsertData(
                schema: "skygreen",
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("21b5ca45-8e5c-4b3c-8702-edeb6d1b1171"), "Power Supplies" },
                    { new Guid("60e3bd68-5aca-41fd-a5cf-687e19bb5f2c"), "Multimeters" }
                });

            migrationBuilder.InsertData(
                schema: "skygreen",
                table: "Holidays",
                columns: new[] { "HolidayId", "Date", "Name" },
                values: new object[,]
                {
                    { new Guid("4364f3e4-d0d4-4181-af49-6d105492af6e"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Year's Day" },
                    { new Guid("9849c5ec-18fe-40cb-b6b7-0544eaf53759"), new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christmas" }
                });

            migrationBuilder.InsertData(
                schema: "skygreen",
                table: "Researches",
                columns: new[] { "ResearchId", "Authors", "FullTextLink", "PublicationDate", "Summary", "ThumbnailImage", "Title" },
                values: new object[,]
                {
                    { new Guid("63dd2024-a160-439b-9d96-f82cbf114b5e"), "Jane Smith", "http://example.com/research2", new DateTime(2024, 5, 25, 23, 28, 50, 84, DateTimeKind.Local).AddTicks(7173), "Summary of the research article 2", "https://images.unsplash.com/photo-1667489022797-ab608913feeb?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHw5fHx8ZW58MHx8fHw%3D&auto=format&fit=crop&w=800&q=60", "Sample Research Title 2" },
                    { new Guid("e52fb795-27fc-4dd3-aa8f-5a53eaa7889d"), "John Doe", "http://example.com/research1", new DateTime(2024, 5, 25, 23, 28, 50, 84, DateTimeKind.Local).AddTicks(7167), "Summary of the research article 1", "https://images.unsplash.com/photo-1667489022797-ab608913feeb?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHw5fHx8ZW58MHx8fHw%3D&auto=format&fit=crop&w=800&q=60", "Sample Research Title 1" }
                });

            migrationBuilder.InsertData(
                schema: "skygreen",
                table: "Supplier",
                columns: new[] { "SupplierId", "Address", "ContactPerson", "CreatedAt", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("7d68ce5e-55a7-4f39-9c28-1f3dbb839cdb"), "456 Elm Street, City, Country", "Jane Smith", new DateTime(2024, 5, 25, 17, 28, 50, 84, DateTimeKind.Utc).AddTicks(6894), "jane.smith@example.com", "Supplier B", "+0987654321" },
                    { new Guid("e669ac6f-5c8b-476e-9531-34c054230982"), "123 Main Street, City, Country", "John Doe", new DateTime(2024, 5, 25, 17, 28, 50, 84, DateTimeKind.Utc).AddTicks(6889), "john.doe@example.com", "Supplier A", "+1234567890" }
                });

            migrationBuilder.InsertData(
                schema: "skygreen",
                table: "Users",
                columns: new[] { "Id", "CurrentAddress", "Department", "Designation", "Email", "FirstName", "IdNumber", "JoinDate", "LastName", "Password", "PhoneNumber", "Session", "Status" },
                values: new object[,]
                {
                    { new Guid("17fa016f-ae8b-4044-80e3-abd54dfe392f"), "Admin Address", "Admin Department", "Admin", "admin@gmail.com", "Admin", "Admin ID", "5/25/2024 5:28:50 PM", "Admin", "admin123", "1234567890", "Admin Session", "" },
                    { new Guid("8fd9fc20-5382-4f44-88fd-c78993a1d8e5"), "Teacher Address", "Teacher Department", "Teacher", "Teacher@gmail.com", "Teacher", "Teacher ID", "5/25/2024 5:28:50 PM", "Teacher", "manager123", "1234567890", "Teacher Session", "" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "AdminAccess", "Administrator", new Guid("17fa016f-ae8b-4044-80e3-abd54dfe392f") },
                    { 2, "TeacherAccess", "Teacher", new Guid("8fd9fc20-5382-4f44-88fd-c78993a1d8e5") }
                });

            migrationBuilder.InsertData(
                schema: "skygreen",
                table: "Branch",
                columns: new[] { "Id", "Address", "CompanyId", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("1d2460e1-088a-4f99-a3e6-43bfb3b2eb49"), "Address of EEE branch", new Guid("f00918a5-3a59-4e3c-9a47-cf36930e7add"), "EEE", "9876543210" },
                    { new Guid("6cec6668-f2f6-43b3-9b35-858a20027db0"), "Address of CSE branch", new Guid("f00918a5-3a59-4e3c-9a47-cf36930e7add"), "CSE", "1234567890" }
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
                name: "IX_Branch_CompanyId",
                schema: "skygreen",
                table: "Branch",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentLogItems_EquipmentLogId",
                schema: "skygreen",
                table: "EquipmentLogItems",
                column: "EquipmentLogId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ReceiverId",
                schema: "skygreen",
                table: "Message",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SenderId",
                schema: "skygreen",
                table: "Message",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_EquipmentId",
                schema: "skygreen",
                table: "PurchaseOrders",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchResults_UserId",
                schema: "skygreen",
                table: "ResearchResults",
                column: "UserId");
        }

        /// <inheritdoc />
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
                name: "Blogs",
                schema: "skygreen");

            migrationBuilder.DropTable(
                name: "Branch",
                schema: "skygreen");

            migrationBuilder.DropTable(
                name: "Chats",
                schema: "skygreen");

            migrationBuilder.DropTable(
                name: "EquipmentLogItems",
                schema: "skygreen");

            migrationBuilder.DropTable(
                name: "FeaturedContents",
                schema: "skygreen");

            migrationBuilder.DropTable(
                name: "Groups",
                schema: "skygreen");

            migrationBuilder.DropTable(
                name: "Holidays",
                schema: "skygreen");

            migrationBuilder.DropTable(
                name: "Message",
                schema: "skygreen");

            migrationBuilder.DropTable(
                name: "PurchaseOrders",
                schema: "skygreen");

            migrationBuilder.DropTable(
                name: "Researches",
                schema: "skygreen");

            migrationBuilder.DropTable(
                name: "ResearchResults",
                schema: "skygreen");

            migrationBuilder.DropTable(
                name: "Supplier",
                schema: "skygreen");

            migrationBuilder.DropTable(
                name: "Thresholds",
                schema: "skygreen");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Company",
                schema: "skygreen");

            migrationBuilder.DropTable(
                name: "EquipmentLogs",
                schema: "skygreen");

            migrationBuilder.DropTable(
                name: "Equipment",
                schema: "skygreen");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "skygreen");
        }
    }
}
