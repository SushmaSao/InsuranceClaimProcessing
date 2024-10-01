using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClaimProcessingService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenameCustomerIdColumnInClaimsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Claims");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Claims",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Claims",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Claims");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Claims",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Claims",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
