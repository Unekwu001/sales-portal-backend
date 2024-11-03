using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserTrackingToAgentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Agents",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "Agents",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Agents",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedById",
                table: "Agents",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedOnUtc",
                table: "Agents",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
 

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "LastUpdatedOnUtc",
                table: "Agents");

             
        }
    }
}
