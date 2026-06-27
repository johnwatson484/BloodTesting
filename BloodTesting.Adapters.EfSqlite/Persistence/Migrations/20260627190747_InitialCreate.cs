using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BloodTesting.Adapters.EfSqlite.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientRecords_Patients_Id",
                        column: x => x.Id,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BloodTests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PatientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TestDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Result = table.Column<int>(type: "INTEGER", nullable: true),
                    PatientRecordId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodTests_PatientRecords_PatientRecordId",
                        column: x => x.PatientRecordId,
                        principalTable: "PatientRecords",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BloodTests_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "DateOfBirth", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Smith" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(1975, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice Johnson" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(1985, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob Williams" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(1992, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carol Davis" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(1968, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "David Brown" },
                    { new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(1995, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emma Wilson" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(1972, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frank Miller" },
                    { new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(1988, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grace Taylor" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(1978, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Henry Anderson" }
                });

            migrationBuilder.InsertData(
                table: "PatientRecords",
                column: "Id",
                values: new object[]
                {
                    new Guid("11111111-1111-1111-1111-111111111111"),
                    new Guid("22222222-2222-2222-2222-222222222222"),
                    new Guid("33333333-3333-3333-3333-333333333333"),
                    new Guid("44444444-4444-4444-4444-444444444444"),
                    new Guid("55555555-5555-5555-5555-555555555555"),
                    new Guid("66666666-6666-6666-6666-666666666666"),
                    new Guid("77777777-7777-7777-7777-777777777777"),
                    new Guid("88888888-8888-8888-8888-888888888888"),
                    new Guid("99999999-9999-9999-9999-999999999999"),
                    new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa")
                });

            migrationBuilder.CreateIndex(
                name: "IX_BloodTests_PatientId",
                table: "BloodTests",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodTests_PatientRecordId",
                table: "BloodTests",
                column: "PatientRecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodTests");

            migrationBuilder.DropTable(
                name: "PatientRecords");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
