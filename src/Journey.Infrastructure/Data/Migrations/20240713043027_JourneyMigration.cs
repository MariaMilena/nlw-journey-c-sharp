using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Journey.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class JourneyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    TripId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activity_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "EndDate", "Name", "StartDate" },
                values: new object[,]
                {
                    { new Guid("4d598a32-27a0-48b2-9d4f-631022b81841"), new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Viagem a Paris", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a31b64f8-54c3-467c-995e-c0b0e463ec67"), new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Viagem ao Japão", new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Activity",
                columns: new[] { "Id", "Date", "Name", "Status", "TripId" },
                values: new object[,]
                {
                    { new Guid("57d2df16-2c71-4190-9f73-30325fecd214"), new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visita a Tokyo Tower", 0, new Guid("a31b64f8-54c3-467c-995e-c0b0e463ec67") },
                    { new Guid("5b3d712d-dd58-45f4-bf11-1487a5c8417f"), new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visita a Kyoto", 0, new Guid("4d598a32-27a0-48b2-9d4f-631022b81841") },
                    { new Guid("7376c29d-2a7e-4b57-8f15-107ffe44c6b1"), new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Passeio em Shibuya", 0, new Guid("a31b64f8-54c3-467c-995e-c0b0e463ec67") },
                    { new Guid("a34dede2-7489-4e80-944d-4a25b6198966"), new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cruzamento no Rio Sena", 0, new Guid("4d598a32-27a0-48b2-9d4f-631022b81841") },
                    { new Guid("b11cd790-4656-4249-ac59-ac1842a40f4f"), new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visita a Kyoto", 0, new Guid("a31b64f8-54c3-467c-995e-c0b0e463ec67") },
                    { new Guid("d1400573-70f3-4af7-b895-a5e87a0e0f03"), new DateTime(2024, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visita a Torre Eiffel", 0, new Guid("4d598a32-27a0-48b2-9d4f-631022b81841") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_TripId",
                table: "Activity",
                column: "TripId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
