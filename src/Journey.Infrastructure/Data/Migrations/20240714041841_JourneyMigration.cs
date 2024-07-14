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
                name: "Activities",
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
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Trips_TripId",
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
                    { new Guid("b01dfe10-8d9d-4b30-9074-25eaf4ac6b3f"), new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Viagem a Paris", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c47f61e0-5e44-4589-99cd-42144e3ec2e6"), new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Viagem ao Japão", new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Date", "Name", "Status", "TripId" },
                values: new object[,]
                {
                    { new Guid("97a72555-d2aa-440d-9499-f5f307e62d18"), new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cruzamento no Rio Sena", 0, new Guid("b01dfe10-8d9d-4b30-9074-25eaf4ac6b3f") },
                    { new Guid("9c5d9336-ccc7-4683-b1f6-651bdd28bbbe"), new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visita a Kyoto", 0, new Guid("c47f61e0-5e44-4589-99cd-42144e3ec2e6") },
                    { new Guid("b7df654c-b71e-408b-8ad9-a5dc03c544c0"), new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visita a Kyoto", 0, new Guid("b01dfe10-8d9d-4b30-9074-25eaf4ac6b3f") },
                    { new Guid("c5b3c55b-3b9f-44be-97e0-4cf14505bcca"), new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visita a Tokyo Tower", 0, new Guid("c47f61e0-5e44-4589-99cd-42144e3ec2e6") },
                    { new Guid("cfdd3b41-4ba1-46de-ad2b-30ae54a36c23"), new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Passeio em Shibuya", 0, new Guid("c47f61e0-5e44-4589-99cd-42144e3ec2e6") },
                    { new Guid("d369011f-3621-47d5-bb23-72c19eb70fdf"), new DateTime(2024, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visita a Torre Eiffel", 0, new Guid("b01dfe10-8d9d-4b30-9074-25eaf4ac6b3f") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_TripId",
                table: "Activities",
                column: "TripId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
