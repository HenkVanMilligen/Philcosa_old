using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Philcosa.Infrastructure.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IssuedByEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssuedByEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostcardTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostcardTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostcardValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    MinValue = table.Column<decimal>(type: "numeric(18,6)", nullable: true),
                    MaxValue = table.Column<decimal>(type: "numeric(18,6)", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostcardValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Postcards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PostcardDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdOnDate = table.Column<string>(type: "text", nullable: true),
                    IssuedById = table.Column<int>(type: "integer", nullable: true),
                    Number = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    AmountIssued = table.Column<string>(type: "text", nullable: true),
                    Atlas = table.Column<string>(type: "text", nullable: true),
                    Alberta = table.Column<string>(type: "text", nullable: true),
                    PostcardTypeId = table.Column<int>(type: "integer", nullable: true),
                    PostcardValueId = table.Column<int>(type: "integer", nullable: true),
                    CountryId = table.Column<int>(type: "integer", nullable: true),
                    Path = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postcards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Postcards_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Postcards_IssuedByEntities_IssuedById",
                        column: x => x.IssuedById,
                        principalTable: "IssuedByEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Postcards_PostcardTypes_PostcardTypeId",
                        column: x => x.PostcardTypeId,
                        principalTable: "PostcardTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Postcards_PostcardValues_PostcardValueId",
                        column: x => x.PostcardValueId,
                        principalTable: "PostcardValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostcardThemes",
                columns: table => new
                {
                    PostcardId = table.Column<int>(type: "integer", nullable: false),
                    ThemeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostcardThemes", x => new { x.PostcardId, x.ThemeId });
                    table.ForeignKey(
                        name: "FK_PostcardThemes_Postcards_PostcardId",
                        column: x => x.PostcardId,
                        principalTable: "Postcards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostcardThemes_Themes_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "Themes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, "VEN", new DateTime(2021, 5, 19, 14, 18, 39, 109, DateTimeKind.Local).AddTicks(4233), "DataSeed", null, null, "Venda" },
                    { 2, "TRA", new DateTime(2021, 5, 19, 14, 18, 39, 114, DateTimeKind.Local).AddTicks(5369), "DataSeed", null, null, "Transkei" },
                    { 3, "CIS", new DateTime(2021, 5, 19, 14, 18, 39, 114, DateTimeKind.Local).AddTicks(5476), "DataSeed", null, null, "Ciskei" },
                    { 4, "BOP", new DateTime(2021, 5, 19, 14, 18, 39, 114, DateTimeKind.Local).AddTicks(5480), "DataSeed", null, null, "Bophuthatswana" },
                    { 5, "SWA", new DateTime(2021, 5, 19, 14, 18, 39, 114, DateTimeKind.Local).AddTicks(5483), "DataSeed", null, null, "South West Africa" },
                    { 6, "RSA", new DateTime(2021, 5, 19, 14, 18, 39, 114, DateTimeKind.Local).AddTicks(5487), "DataSeed", null, null, "South Africa" },
                    { 7, "NAM", new DateTime(2021, 5, 19, 14, 18, 39, 114, DateTimeKind.Local).AddTicks(5490), "DataSeed", null, null, "Namibia" }
                });

            migrationBuilder.InsertData(
                table: "IssuedByEntities",
                columns: new[] { "Id", "Code", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 22, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9067), "DataSeed", null, null, "Private" },
                    { 23, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9069), "DataSeed", null, null, "SA Transport Services" },
                    { 24, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9070), "DataSeed", null, null, "Simonstown Historical Society" },
                    { 25, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9072), "DataSeed", null, null, "Warner Pharmaceuticals" },
                    { 26, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9073), "DataSeed", null, null, "SA Air Force Museum (Original Series)" },
                    { 27, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9075), "DataSeed", null, null, "Kempton Park Philatelic Society (Kemp Maksikard)" },
                    { 28, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9077), "DataSeed", null, null, "SA Railway Services" },
                    { 29, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9078), "DataSeed", null, null, "Kempton Park Philatelic Society (Kemp Kover)" },
                    { 32, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9083), "DataSeed", null, null, "Foreign Airline" },
                    { 31, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9081), "DataSeed", null, null, "SA Air Force Museum (Spesials)" },
                    { 21, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9066), "DataSeed", null, null, "South African Airways Museum" },
                    { 33, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9084), "DataSeed", null, null, "SA Navy" },
                    { 34, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9088), "DataSeed", null, null, "Caprivi Airways" },
                    { 35, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9090), "DataSeed", null, null, "SA Air Force Museum (Anniversary Flights)" },
                    { 36, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9091), "DataSeed", null, null, "Flitestar" },
                    { 37, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9093), "DataSeed", null, null, "Airphilsa" },
                    { 30, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9080), "DataSeed", null, null, "SA Air Force Museum (World War Series)" },
                    { 20, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9064), "DataSeed", null, null, "Federation" },
                    { 17, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9027), "DataSeed", null, null, "Ship Society of SA" },
                    { 18, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9061), "DataSeed", null, null, "South African Airways" },
                    { 1, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(8291), "DataSeed", null, null, "Kempton Park Philatelic Society (Kemp kard)" },
                    { 2, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(8984), "DataSeed", null, null, "First Day Fabrics (Silk)" },
                    { 3, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9001), "DataSeed", null, null, "South African Air Force (Aerobic)" },
                    { 4, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9003), "DataSeed", null, null, "SA Army" },
                    { 5, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9005), "DataSeed", null, null, "Namib AirAir Namibia (Delivery flights)" },
                    { 6, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9008), "DataSeed", null, null, "United Nations" },
                    { 7, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9010), "DataSeed", null, null, "World Wildlife Fund" },
                    { 19, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9062), "DataSeed", null, null, "SA Philatelic Foundation" },
                    { 8, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9012), "DataSeed", null, null, "Namib AirAir Namibia" },
                    { 10, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9016), "DataSeed", null, null, "Kempton Park Philatelic Society (Kemp Air)" },
                    { 11, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9017), "DataSeed", null, null, "The Railway Society" },
                    { 12, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9019), "DataSeed", null, null, "SA Police" },
                    { 13, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9020), "DataSeed", null, null, "Simonstown Navy Museum" },
                    { 14, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9022), "DataSeed", null, null, "Nam Post" },
                    { 15, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9024), "DataSeed", null, null, "SA Defence Force" },
                    { 16, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9025), "DataSeed", null, null, "SA Post Office" },
                    { 9, null, new DateTime(2021, 5, 19, 14, 18, 39, 127, DateTimeKind.Local).AddTicks(9013), "DataSeed", null, null, "First Day Fabrics (Gold)" }
                });

            migrationBuilder.InsertData(
                table: "PostcardTypes",
                columns: new[] { "Id", "Code", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 7, "FIL", new DateTime(2021, 5, 19, 14, 18, 39, 118, DateTimeKind.Local).AddTicks(639), "DataSeed", null, null, "Filatelic" },
                    { 9, "RWY", new DateTime(2021, 5, 19, 14, 18, 39, 118, DateTimeKind.Local).AddTicks(642), "DataSeed", null, null, "Railway" },
                    { 8, "BAL", new DateTime(2021, 5, 19, 14, 18, 39, 118, DateTimeKind.Local).AddTicks(641), "DataSeed", null, null, "Balloon" },
                    { 6, "MIL", new DateTime(2021, 5, 19, 14, 18, 39, 118, DateTimeKind.Local).AddTicks(637), "DataSeed", null, null, "Military" },
                    { 4, "SLK", new DateTime(2021, 5, 19, 14, 18, 39, 118, DateTimeKind.Local).AddTicks(633), "DataSeed", null, null, "Silk" },
                    { 3, "FLT", new DateTime(2021, 5, 19, 14, 18, 39, 118, DateTimeKind.Local).AddTicks(631), "DataSeed", null, null, "Flight" },
                    { 2, "CMC", new DateTime(2021, 5, 19, 14, 18, 39, 118, DateTimeKind.Local).AddTicks(613), "DataSeed", null, null, "Comemorative" },
                    { 1, "FDC", new DateTime(2021, 5, 19, 14, 18, 39, 118, DateTimeKind.Local).AddTicks(176), "DataSeed", null, null, "First Day" },
                    { 5, "GLD", new DateTime(2021, 5, 19, 14, 18, 39, 118, DateTimeKind.Local).AddTicks(635), "DataSeed", null, null, "Gold Foiled" }
                });

            migrationBuilder.InsertData(
                table: "PostcardValues",
                columns: new[] { "Id", "Code", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "MaxValue", "MinValue" },
                values: new object[,]
                {
                    { 5, "$$$$$", new DateTime(2021, 5, 19, 14, 18, 39, 119, DateTimeKind.Local).AddTicks(1310), "DataSeed", null, null, 500m, 150.01m },
                    { 1, "$", new DateTime(2021, 5, 19, 14, 18, 39, 119, DateTimeKind.Local).AddTicks(316), "DataSeed", null, null, 5m, 0m },
                    { 2, "$$", new DateTime(2021, 5, 19, 14, 18, 39, 119, DateTimeKind.Local).AddTicks(1243), "DataSeed", null, null, 15m, 5.01m },
                    { 3, "$$$", new DateTime(2021, 5, 19, 14, 18, 39, 119, DateTimeKind.Local).AddTicks(1305), "DataSeed", null, null, 50m, 15.01m },
                    { 4, "$$$$", new DateTime(2021, 5, 19, 14, 18, 39, 119, DateTimeKind.Local).AddTicks(1308), "DataSeed", null, null, 150m, 50.01m },
                    { 6, "$$$$$$", new DateTime(2021, 5, 19, 14, 18, 39, 119, DateTimeKind.Local).AddTicks(1312), "DataSeed", null, null, null, 500.01m }
                });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "Id", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 101, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2385), "DataSeed", null, null, "Mushrooms/Fungi" },
                    { 100, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2383), "DataSeed", null, null, "Diplomacy" },
                    { 112, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2407), "DataSeed", null, null, "Jan van Riebeeck" },
                    { 98, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2379), "DataSeed", null, null, "Mining/Minerals" },
                    { 102, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2387), "DataSeed", null, null, "Dams" },
                    { 99, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2381), "DataSeed", null, null, "Forts and Castles" },
                    { 103, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2389), "DataSeed", null, null, "Languages" },
                    { 108, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2400), "DataSeed", null, null, "Rugby" },
                    { 105, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2394), "DataSeed", null, null, "Arts/Culture/Traditions" },
                    { 106, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2396), "DataSeed", null, null, "Archaeology" },
                    { 107, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2398), "DataSeed", null, null, "Telecommunication" },
                    { 97, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2377), "DataSeed", null, null, "Windmills" },
                    { 109, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2402), "DataSeed", null, null, "Fish and Marine Life" },
                    { 110, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2403), "DataSeed", null, null, "van Riebeeck" },
                    { 111, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2406), "DataSeed", null, null, "Orchids" },
                    { 104, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2391), "DataSeed", null, null, "Sharks" },
                    { 96, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2375), "DataSeed", null, null, "Boxing" },
                    { 90, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2363), "DataSeed", null, null, "Olympic Games" },
                    { 94, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2371), "DataSeed", null, null, "Spiders" },
                    { 78, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2315), "DataSeed", null, null, "Platinum" },
                    { 79, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2318), "DataSeed", null, null, "Literature/Writers" },
                    { 80, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2319), "DataSeed", null, null, "Unicef" },
                    { 81, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2322), "DataSeed", null, null, "Rivers" },
                    { 82, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2323), "DataSeed", null, null, "Royals" },
                    { 83, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2326), "DataSeed", null, null, "National Festivals" },
                    { 84, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2328), "DataSeed", null, null, "United Nations" },
                    { 85, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2330), "DataSeed", null, null, "Manufacturing/Industries" },
                    { 86, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2332), "DataSeed", null, null, "Space" },
                    { 87, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2334), "DataSeed", null, null, "Fossils" },
                    { 88, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2336), "DataSeed", null, null, "Birds" },
                    { 89, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2338), "DataSeed", null, null, "Meteorology/Weather" },
                    { 91, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2366), "DataSeed", null, null, "Astronomy" },
                    { 92, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2367), "DataSeed", null, null, "Weapons" },
                    { 93, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2370), "DataSeed", null, null, "Millenium" },
                    { 95, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2374), "DataSeed", null, null, "Settlers" },
                    { 113, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2410), "DataSeed", null, null, "Flight and Aircraft" },
                    { 143, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2458), "DataSeed", null, null, "Energy" },
                    { 115, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2413), "DataSeed", null, null, "Folklore" },
                    { 136, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2447), "DataSeed", null, null, "Monuments" },
                    { 137, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2449), "DataSeed", null, null, "Wildlife" },
                    { 138, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2450), "DataSeed", null, null, "Community Services" },
                    { 139, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2452), "DataSeed", null, null, "Uniforms" },
                    { 140, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2454), "DataSeed", null, null, "Ships/Maritime" },
                    { 141, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2455), "DataSeed", null, null, "Reptiles" },
                    { 142, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2457), "DataSeed", null, null, "Triangle Stamps" },
                    { 77, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2313), "DataSeed", null, null, "Health/Medicine" },
                    { 144, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2460), "DataSeed", null, null, "Child" },
                    { 145, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2461), "DataSeed", null, null, "Snakes" },
                    { 146, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2463), "DataSeed", null, null, "Stamp Day" },
                    { 147, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2464), "DataSeed", null, null, "Watersports" },
                    { 148, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2466), "DataSeed", null, null, "Waterfalls" },
                    { 149, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2468), "DataSeed", null, null, "Military" },
                    { 150, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2469), "DataSeed", null, null, "Rotary International" },
                    { 135, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2446), "DataSeed", null, null, "Butterflies" },
                    { 134, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2444), "DataSeed", null, null, "Towns/Cities History" },
                    { 133, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2443), "DataSeed", null, null, "Snails" },
                    { 132, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2441), "DataSeed", null, null, "Balloon Flights" },
                    { 116, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2415), "DataSeed", null, null, "Cars" },
                    { 117, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2417), "DataSeed", null, null, "Gold" },
                    { 118, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2418), "DataSeed", null, null, "Afrikaans language" },
                    { 119, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2420), "DataSeed", null, null, "Communication" },
                    { 120, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2421), "DataSeed", null, null, "Boy Scouts" },
                    { 121, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2423), "DataSeed", null, null, "Bats" },
                    { 122, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2424), "DataSeed", null, null, "Solar System" },
                    { 114, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2411), "DataSeed", null, null, "Telephone" },
                    { 123, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2426), "DataSeed", null, null, "Architecture" },
                    { 125, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2429), "DataSeed", null, null, "Dinosaurs" },
                    { 126, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2431), "DataSeed", null, null, "Presidents and Leaders" },
                    { 127, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2432), "DataSeed", null, null, "Bridges" },
                    { 128, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2434), "DataSeed", null, null, "Museums" },
                    { 129, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2435), "DataSeed", null, null, "Hunting" },
                    { 130, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2438), "DataSeed", null, null, "Flora/Flowers" },
                    { 131, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2440), "DataSeed", null, null, "Constitution" },
                    { 124, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2427), "DataSeed", null, null, "Scuptures" },
                    { 76, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2312), "DataSeed", null, null, "Cricket" },
                    { 47, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2248), "DataSeed", null, null, "Equestrian" },
                    { 74, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2308), "DataSeed", null, null, "Motorsport" },
                    { 20, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2184), "DataSeed", null, null, "Child Paintings" },
                    { 21, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2186), "DataSeed", null, null, "Turtles" },
                    { 22, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2189), "DataSeed", null, null, "WWF" },
                    { 23, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2191), "DataSeed", null, null, "Religion/Churches" },
                    { 24, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2194), "DataSeed", null, null, "Lions International" },
                    { 25, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2196), "DataSeed", null, null, "Boer War" },
                    { 26, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2198), "DataSeed", null, null, "Red Cross" },
                    { 27, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2201), "DataSeed", null, null, "Trees" },
                    { 28, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2203), "DataSeed", null, null, "Easter" },
                    { 29, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2205), "DataSeed", null, null, "Dogs" },
                    { 30, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2207), "DataSeed", null, null, "Transport" },
                    { 31, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2210), "DataSeed", null, null, "Gem Stones/Jewels" },
                    { 32, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2212), "DataSeed", null, null, "Railway/Trains" },
                    { 33, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2214), "DataSeed", null, null, "History" },
                    { 34, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2218), "DataSeed", null, null, "Shells" },
                    { 19, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2182), "DataSeed", null, null, "Costumes" },
                    { 35, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2220), "DataSeed", null, null, "Geology" },
                    { 18, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2179), "DataSeed", null, null, "Frogs" },
                    { 16, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2174), "DataSeed", null, null, "Swimming" },
                    { 1, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(1628), "DataSeed", null, null, "ITU" },
                    { 2, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2089), "DataSeed", null, null, "Famous Persons" },
                    { 3, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2100), "DataSeed", null, null, "Sport" },
                    { 4, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2102), "DataSeed", null, null, "Police" },
                    { 5, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2105), "DataSeed", null, null, "UPU" },
                    { 6, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2110), "DataSeed", null, null, "Mandela" },
                    { 7, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2112), "DataSeed", null, null, "Fishing/Angling" },
                    { 8, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2114), "DataSeed", null, null, "Landscapes/Nature" },
                    { 9, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2117), "DataSeed", null, null, "Heraldry/Coat of Arms" },
                    { 10, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2120), "DataSeed", null, null, "Water and Sanitation" },
                    { 11, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2162), "DataSeed", null, null, "Agriculture/Farming" },
                    { 12, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2164), "DataSeed", null, null, "Golf" },
                    { 13, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2167), "DataSeed", null, null, "Cartoon" },
                    { 14, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2169), "DataSeed", null, null, "Lizards" },
                    { 15, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2171), "DataSeed", null, null, "Law" },
                    { 17, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2176), "DataSeed", null, null, "Stamp on Stamps" },
                    { 36, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2223), "DataSeed", null, null, "Cats" },
                    { 37, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2225), "DataSeed", null, null, "Grasses" },
                    { 38, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2228), "DataSeed", null, null, "Whales" },
                    { 59, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2276), "DataSeed", null, null, "Submarines" },
                    { 60, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2278), "DataSeed", null, null, "Monkeys and Baboons" },
                    { 61, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2281), "DataSeed", null, null, "Stamp Exhibition" },
                    { 62, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2283), "DataSeed", null, null, "Fruits" },
                    { 63, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2285), "DataSeed", null, null, "Road Safety" },
                    { 64, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2288), "DataSeed", null, null, "Mountains" },
                    { 65, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2290), "DataSeed", null, null, "Forestry/Trees" },
                    { 66, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2293), "DataSeed", null, null, "Atletics" },
                    { 67, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2295), "DataSeed", null, null, "Voortrekkers" },
                    { 68, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2296), "DataSeed", null, null, "Insects" },
                    { 69, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2298), "DataSeed", null, null, "Roses" },
                    { 70, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2300), "DataSeed", null, null, "Tourism" },
                    { 71, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2302), "DataSeed", null, null, "Postal History" },
                    { 72, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2304), "DataSeed", null, null, "Musical Instruments" },
                    { 73, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2305), "DataSeed", null, null, "Music" },
                    { 58, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2274), "DataSeed", null, null, "Helicopters" },
                    { 57, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2272), "DataSeed", null, null, "Wines and Beer" },
                    { 56, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2269), "DataSeed", null, null, "Horses" },
                    { 55, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2267), "DataSeed", null, null, "Hares/Rabbits" },
                    { 39, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2230), "DataSeed", null, null, "Apartheid" },
                    { 40, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2232), "DataSeed", null, null, "Government and Politics" },
                    { 41, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2234), "DataSeed", null, null, "Football/Soccer" },
                    { 42, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2237), "DataSeed", null, null, "Tennis" },
                    { 43, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2239), "DataSeed", null, null, "Hockey" },
                    { 44, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2241), "DataSeed", null, null, "Chicken" },
                    { 45, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2244), "DataSeed", null, null, "Nursing" },
                    { 75, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2309), "DataSeed", null, null, "Antarctica" },
                    { 46, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2246), "DataSeed", null, null, "Flags" },
                    { 48, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2251), "DataSeed", null, null, "Disabled" },
                    { 49, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2253), "DataSeed", null, null, "Owls" },
                    { 50, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2255), "DataSeed", null, null, "Definitive Series" },
                    { 51, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2257), "DataSeed", null, null, "Girl Guides" },
                    { 52, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2260), "DataSeed", null, null, "Maps" },
                    { 53, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2262), "DataSeed", null, null, "Christmas" },
                    { 54, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2264), "DataSeed", null, null, "Science and Technology" },
                    { 151, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2471), "DataSeed", null, null, "Paintings" },
                    { 152, new DateTime(2021, 5, 19, 14, 18, 39, 124, DateTimeKind.Local).AddTicks(2472), "DataSeed", null, null, "Education" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Postcards_CountryId",
                table: "Postcards",
                column: "CountryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Postcards_IssuedById",
                table: "Postcards",
                column: "IssuedById",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Postcards_PostcardTypeId",
                table: "Postcards",
                column: "PostcardTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Postcards_PostcardValueId",
                table: "Postcards",
                column: "PostcardValueId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostcardThemes_ThemeId",
                table: "PostcardThemes",
                column: "ThemeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostcardThemes");

            migrationBuilder.DropTable(
                name: "Postcards");

            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "IssuedByEntities");

            migrationBuilder.DropTable(
                name: "PostcardTypes");

            migrationBuilder.DropTable(
                name: "PostcardValues");
        }
    }
}
