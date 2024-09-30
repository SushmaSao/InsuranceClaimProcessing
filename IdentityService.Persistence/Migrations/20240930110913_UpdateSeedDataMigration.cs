using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdentityService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedDataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2a2840a2-cdce-4f6f-b884-2b32cdd81937"), "User" },
                    { new Guid("36f54c54-9a96-49c4-9443-0da90bde37fe"), "Agent" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2a2840a2-cdce-4f6f-b884-2b32cdd81937"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("36f54c54-9a96-49c4-9443-0da90bde37fe"));
        }
    }
}
