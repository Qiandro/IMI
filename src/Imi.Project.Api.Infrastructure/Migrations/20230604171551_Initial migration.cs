using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Imi.Project.Api.Infrastructure.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastOnline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HasApprovedTermsAndConditions = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_groups_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => new { x.GroupId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Admin_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admin_groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_events_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_events_groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_members", x => new { x.GroupId, x.UserId });
                    table.ForeignKey(
                        name: "FK_members_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_members_groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastEditedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_messages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_messages_groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "HasApprovedTermsAndConditions", "LastName", "LastOnline", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000001", 0, new DateTime(2001, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "d079109c-9578-4dad-a647-2a90e7875ed9", "Qiandro.claeys@gmail.com", true, "Qiandro", true, "Claeys", new DateTime(2023, 6, 4, 19, 15, 50, 793, DateTimeKind.Local).AddTicks(7749), false, null, "QIANDRO.CLAEYS@GMAIL.COM", "QIANDRO.CLAEYS@GMAIL.COM", "AQAAAAEAACcQAAAAENzAFE5dh6iXjD5xjAsKy3FOvqqPlxOIoTgTyoJvaiF9uGD5Om/lJqi6gfS/p4qIlg==", null, true, "4f7f1e2d-5992-4574-934d-bcfb36c9bc74", false, "Qiandro.claeys@gmail.com" },
                    { "00000000-0000-0000-0000-000000000002", 0, new DateTime(2003, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "65498c2d-c1cb-470c-a806-bea5f7ad5a33", "Qienta.claeys@gmail.com", true, "Qienta", true, "Claeys", new DateTime(2023, 6, 4, 19, 15, 50, 793, DateTimeKind.Local).AddTicks(7802), false, null, "QIENTA.CLAEYS@GMAIL.COM", "QIENTA.CLAEYS@GMAIL.COM", "AQAAAAEAACcQAAAAEC802osVnDn4BzN6VJIvo7mw/k+s7wO1pF6CrfRDYaJGV7nCgh/XAROk2ESfFg9oeA==", null, true, "4f94e17a-d92c-4f99-8e29-f506b666aa5f", false, "Qienta.claeys@gmail.com" },
                    { "00000000-0000-0000-0000-000000000003", 0, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "c1d8e1fd-3be7-459b-8e18-9648442efff2", "Taina.reubens@proximus.be", true, "Taina", true, "Reubens", new DateTime(2023, 6, 4, 19, 15, 50, 793, DateTimeKind.Local).AddTicks(7830), false, null, "TAINA.REUBENS@PROXIMUS.BE", "TAINA.REUBENS@PROXIMUS.BE", "AQAAAAEAACcQAAAAECHHFtCrGCba9pQkhuOyiZ/FaEYT2JtMmNKkZmSR0hhh2b5MtgEdaxlEgqzavonH4Q==", null, true, "4edb37c4-f95d-41cd-9f0e-a97ebf4f67d7", false, "Taina.reubens@proximus.be" },
                    { "00000000-0000-0000-0000-000000000004", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ff4f715f-dbd6-4038-a70e-29f92f7b3313", "Gianni.claeys@proximus.be", true, "Gianni", true, "Claeys", new DateTime(2023, 6, 4, 19, 15, 50, 793, DateTimeKind.Local).AddTicks(7845), false, null, "GIANNI.CLAEYS@PROXIMUS.BE", "GIANNI.CLAEYS@PROXIMUS.BE", "AQAAAAEAACcQAAAAEMRvOTolLDJxQv04mG7yTz7vQ/PayDKjTGBqcdY/8L2wtL2chwesWxSP4HkoB4gLLg==", null, true, "75f40e67-128d-4b90-af6e-f39e6ca6584f", false, "Gianni.claeys@proximus.be" },
                    { "00000000-0000-0000-0000-000000000005", 0, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "295274b5-b76b-43f3-a152-7b5b0e211f71", "Joeri.Versyck@gmail.com", true, "Joeri", true, "Versyck", new DateTime(2023, 6, 4, 19, 15, 50, 793, DateTimeKind.Local).AddTicks(7857), false, null, "JOERI.VERSYCK@GMAIL.COM", "JOERI.VERSYCK@GMAIL.COM", "AQAAAAEAACcQAAAAEHLUCRAmyA73LAdxljrvoNeBaKyNT4E+YrXnQijJCqK0zatJEy3RinueV7zpwL4njw==", null, true, "149c48a7-3074-439a-abfe-2881b9b2e480", false, "Joeri.Versyck@gmail.com" },
                    { "00000000-0000-0000-0000-000000000006", 0, new DateTime(1998, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "fa1d81c0-d7f9-4d2d-accf-20ba9a760dbd", "Kevin.Rooseboom@gmail.com", true, "Kevin", true, "Rooseboom", new DateTime(2023, 6, 4, 19, 15, 50, 793, DateTimeKind.Local).AddTicks(7874), false, null, "KEVIN.ROOSEBOOM@GMAIL.COM", "KEVIN.ROOSEBOOM@GMAIL.COM", "AQAAAAEAACcQAAAAEFGxEhE5aRqlgOdqY86RHhgdONJK98/EJYWMU/rqO40Dhsd6N1PpHOdLaHIHsSJ+Vw==", null, true, "96036117-f89f-402f-86aa-36934ee975b9", false, "Kevin.Rooseboom@gmail.com" },
                    { "00000000-0000-0000-0000-000000000007", 0, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "f5e873f6-8c6e-4201-81a4-4708454154bb", "Lieven.Geryl@gmail.com", true, "Lieven", true, "Geryl", new DateTime(2023, 6, 4, 19, 15, 50, 793, DateTimeKind.Local).AddTicks(7887), false, null, "LIEVEN.GERYL@GMAIL.COM", "LIEVEN.GERYL@GMAIL.COM", "AQAAAAEAACcQAAAAENtrrQkIIA3PwLE1MbBhL5whDHwKQK3N0Q4zci0piHQiLWTPqkeoPha2+wlp7Ay8fg==", null, true, "4e9601ca-c2b4-4aaa-a1bb-093b88d69b3a", false, "Lieven.Geryl@gmail.com" },
                    { "00000000-0000-0000-0000-000000000008", 0, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5f5e43d9-6416-48e7-b7fc-36f60e1a7dbe", "Miblan@gmail.com", true, "Michiel", true, "Blancquaert", new DateTime(2023, 6, 4, 19, 15, 50, 793, DateTimeKind.Local).AddTicks(7903), false, null, "MIBLAN@GMAIL.COM", "MIBLAN@GMAIL.COM", "AQAAAAEAACcQAAAAEJU+KQxTTVPRXMME784Nz6WO8GjJAVCOuQKVzeYS3QCEKSDgBlxiYSsIthp4mqO6sw==", null, true, "4f0f1876-7f6b-4950-a088-ee9cd21a4b24", false, "Miblan@gmail.com" },
                    { "00000000-0000-0000-0000-000000000009", 0, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "e9c0425b-7b05-4628-8e31-8f1c7ae7a8bc", "Ashley.Senaeve@gmail.com", true, "Ashley", true, "Senaeve", new DateTime(2023, 6, 4, 19, 15, 50, 793, DateTimeKind.Local).AddTicks(7916), false, null, "ASHLEY.SENAEVE@GMAIL.COM", "ASHLEY.SENAEVE@GMAIL.COM", "AQAAAAEAACcQAAAAECjprtiPgGyZ01ZJITSS1zk8XgI1xtvMzyEB8qX/x7RXqlj3lR66xHbhioCkk0+F+w==", null, true, "b7cebd4b-7f56-49dd-89ab-4bcdb011ef3a", false, "Ashley.Senaeve@gmail.com" },
                    { "00000000-0000-0000-0000-000000000010", 0, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "606a91e7-867c-45f2-a606-34fa6739225b", "Kim.Sabbe@gmail.com", true, "Kimberly", true, "Sabbe", new DateTime(2023, 6, 4, 19, 15, 50, 793, DateTimeKind.Local).AddTicks(7929), false, null, "KIM.SABBE@GMAIL.COM", "KIM.SABBE@GMAIL.COM", "AQAAAAEAACcQAAAAEHSuc3GnQEr1v/F20W1OVz13dfL8YNpWBbfJhE1WiB4qsgwk6ykVz3nhGg8XA5EwXg==", null, true, "82aca335-87b9-478a-8eed-2b6e196fe5e4", false, "Kim.sabbe@GMAIL.COM" },
                    { "00000000-0000-0000-0000-000000000011", 0, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1a5cb8ec-41db-4abd-a878-45fcf51fbfa8", "Damien.Maddens@gmail.com", true, "Damien", true, "Maddens", new DateTime(2023, 6, 4, 19, 15, 50, 793, DateTimeKind.Local).AddTicks(7944), false, null, "DAMIEN.MADDENS@GMAIL.COM", "DAMIEN.MADDENS@GMAIL.COM", "AQAAAAEAACcQAAAAEJTy4N8Qcbmzfm+gkL9e/ymmVbZSo7djuxoK0Bq50VXBhYX6vP5GvVBkLH6pVFJJCQ==", null, true, "87b70b69-9383-4209-b86f-e347ad65b3b0", false, "Damien.maddens@GMAIL.COM" },
                    { "00000000-0000-0000-0000-000000000012", 0, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "832ab9e8-e176-4552-b485-12138d89d717", "user@imi.be", true, "Imi", true, "User", new DateTime(2023, 6, 4, 19, 15, 50, 793, DateTimeKind.Local).AddTicks(7958), false, null, "USER@IMI.BE", "USER@IMI.BE", "AQAAAAEAACcQAAAAEES9bKShLnpTZNM/VVhx6FZuQxlZQmapweEdZJUgDjLnpaRVAmrNgoaJlxEeNgE1gA==", null, true, "d40fe828-2b59-4690-8784-a802b112168e", false, "user@imi.be" },
                    { "00000000-0000-0000-0000-000000000013", 0, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9033f80d-900c-461d-b2d9-0bb1165675d2", "refuser@imi.be", true, "Imi", false, "Refuser", new DateTime(2023, 6, 4, 19, 15, 50, 793, DateTimeKind.Local).AddTicks(7972), false, null, "REFUSER@IMI.BE", "REFUSER@IMI.BE", "AQAAAAEAACcQAAAAEAJEI+4qJFMMcQYfK330///EJ9Oo9GPWlwkc1Qbkf7ylCHg9/GocMxI7u2oFn5aF8A==", null, true, "ac1a3d91-007c-435c-9d3a-ea3f28cc0d8f", false, "refuser@imi.be" },
                    { "00000000-0000-0000-0000-000000000014", 0, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6d6a11e0-3a93-45aa-a041-77334035f6a9", "admin@imi.be", true, "admin", true, "admin", new DateTime(2023, 6, 4, 19, 15, 50, 793, DateTimeKind.Local).AddTicks(8065), false, null, "ADMIN@IMI.BE", "ADMIN@IMI.BE", "AQAAAAEAACcQAAAAEFHCqHiSxE6EOF63qOdHdcA5GbORfsmn35CTO6EX6+cVoK/WVYErBXPAjJY/exEsdg==", null, true, "cc3ba9cb-79e2-4b8a-b860-f4b06657751b", false, "admin@imi.be" }
                });

            migrationBuilder.InsertData(
                table: "groups",
                columns: new[] { "Id", "CreatorId", "Img", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "00000000-0000-0000-0000-000000000001", "", "Familie Claeys" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "00000000-0000-0000-0000-000000000001", "", "Friends" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "00000000-0000-0000-0000-000000000001", "", "PROG klas" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "00000000-0000-0000-0000-000000000001", "", "Testgroep1" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "00000000-0000-0000-0000-000000000001", "", "Testgroep2" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "00000000-0000-0000-0000-000000000001", "", "Testgroep3" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "00000000-0000-0000-0000-000000000001", "", "Testgroep4" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "00000000-0000-0000-0000-000000000001", "", "Testgroep5" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "00000000-0000-0000-0000-000000000001", "", "Testgroep6" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "00000000-0000-0000-0000-000000000001", "", "Testgroep7" }
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "GroupId", "UserId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "00000000-0000-0000-0000-000000000001" },
                    { new Guid("00000000-0000-0000-0000-000000000001"), "00000000-0000-0000-0000-000000000002" },
                    { new Guid("00000000-0000-0000-0000-000000000001"), "00000000-0000-0000-0000-000000000003" },
                    { new Guid("00000000-0000-0000-0000-000000000001"), "00000000-0000-0000-0000-000000000004" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "00000000-0000-0000-0000-000000000010" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "00000000-0000-0000-0000-000000000011" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "00000000-0000-0000-0000-000000000001" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "00000000-0000-0000-0000-000000000007" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "00000000-0000-0000-0000-000000000008" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "00000000-0000-0000-0000-000000000009" }
                });

            migrationBuilder.InsertData(
                table: "events",
                columns: new[] { "EventId", "CreationDate", "CreatorId", "DeletedOn", "Description", "EndDate", "GroupId", "LastEditedOn", "Name", "StartDate" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Local), "00000000-0000-0000-0000-000000000001", null, "We gaan met de familie naar plopsaland en tante gaat mee", new DateTime(2023, 8, 20, 18, 30, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000001"), null, "Dagje Plopsaland", new DateTime(2023, 8, 20, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Local), "00000000-0000-0000-0000-000000000002", null, "Inspuiting voor qienta haar reuma", new DateTime(2023, 5, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000001"), null, "Inspuiting Qienta", new DateTime(2023, 5, 3, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Local), "00000000-0000-0000-0000-000000000001", null, "Film gaan kijken in kinepolis brugge", new DateTime(2023, 4, 29, 16, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000002"), null, "Cinema", new DateTime(2023, 4, 29, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Local), "00000000-0000-0000-0000-000000000005", null, "Aanwezig", new DateTime(2023, 4, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000003"), null, "les", new DateTime(2023, 4, 28, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Local), "00000000-0000-0000-0000-000000000006", null, "Aanwezig", new DateTime(2023, 4, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000003"), null, "les", new DateTime(2023, 4, 28, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Local), "00000000-0000-0000-0000-000000000007", null, "Aanwezig", new DateTime(2023, 4, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000003"), null, "les", new DateTime(2023, 4, 28, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Local), "00000000-0000-0000-0000-000000000008", null, "Aanwezig", new DateTime(2023, 4, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000003"), null, "les", new DateTime(2023, 4, 28, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Local), "00000000-0000-0000-0000-000000000001", null, "Aanwezig", new DateTime(2023, 4, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000003"), null, "les", new DateTime(2023, 4, 28, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Local), "00000000-0000-0000-0000-000000000009", null, "Aanwezig", new DateTime(2023, 4, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000003"), null, "les", new DateTime(2023, 4, 28, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Local), "00000000-0000-0000-0000-000000000001", null, "Smoking cue in torhout", new DateTime(2023, 4, 29, 20, 30, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000002"), null, "Biljart", new DateTime(2023, 4, 29, 17, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "members",
                columns: new[] { "GroupId", "UserId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "00000000-0000-0000-0000-000000000001" },
                    { new Guid("00000000-0000-0000-0000-000000000001"), "00000000-0000-0000-0000-000000000002" },
                    { new Guid("00000000-0000-0000-0000-000000000001"), "00000000-0000-0000-0000-000000000003" },
                    { new Guid("00000000-0000-0000-0000-000000000001"), "00000000-0000-0000-0000-000000000004" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "00000000-0000-0000-0000-000000000001" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "00000000-0000-0000-0000-000000000010" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "00000000-0000-0000-0000-000000000011" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "00000000-0000-0000-0000-000000000001" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "00000000-0000-0000-0000-000000000005" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "00000000-0000-0000-0000-000000000006" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "00000000-0000-0000-0000-000000000007" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "00000000-0000-0000-0000-000000000008" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "00000000-0000-0000-0000-000000000009" }
                });

            migrationBuilder.InsertData(
                table: "messages",
                columns: new[] { "MessageId", "Content", "GroupId", "LastEditedOn", "SenderId", "SentTime" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Hallo dit is een test", new Guid("00000000-0000-0000-0000-000000000001"), null, "00000000-0000-0000-0000-000000000001", new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Hallo dit is (g)een test", new Guid("00000000-0000-0000-0000-000000000001"), null, "00000000-0000-0000-0000-000000000002", new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Hallo dit is een test", new Guid("00000000-0000-0000-0000-000000000002"), null, "00000000-0000-0000-0000-000000000001", new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Hallo dit is een test", new Guid("00000000-0000-0000-0000-000000000003"), null, "00000000-0000-0000-0000-000000000001", new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Hallo", new Guid("00000000-0000-0000-0000-000000000001"), null, "00000000-0000-0000-0000-000000000003", new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "Hallo", new Guid("00000000-0000-0000-0000-000000000001"), null, "00000000-0000-0000-0000-000000000004", new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "Hallo", new Guid("00000000-0000-0000-0000-000000000003"), null, "00000000-0000-0000-0000-000000000005", new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Hallo", new Guid("00000000-0000-0000-0000-000000000003"), null, "00000000-0000-0000-0000-000000000006", new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "Hallo", new Guid("00000000-0000-0000-0000-000000000003"), null, "00000000-0000-0000-0000-000000000007", new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "messages",
                columns: new[] { "MessageId", "Content", "GroupId", "LastEditedOn", "SenderId", "SentTime" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000010"), "Hallo", new Guid("00000000-0000-0000-0000-000000000003"), null, "00000000-0000-0000-0000-000000000008", new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_UserId",
                table: "Admin",
                column: "UserId");

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
                name: "IX_events_CreatorId",
                table: "events",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_events_GroupId",
                table: "events",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_groups_CreatorId",
                table: "groups",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_members_UserId",
                table: "members",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_messages_GroupId",
                table: "messages",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_messages_SenderId",
                table: "messages",
                column: "SenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

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
                name: "events");

            migrationBuilder.DropTable(
                name: "members");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "groups");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
