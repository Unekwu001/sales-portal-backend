using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class KeyFeatureRemovedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeyFeatures");

  

            migrationBuilder.AddColumn<string>(
                name: "KeyFeature1",
                table: "PlanTypes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyFeature2",
                table: "PlanTypes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyFeature3",
                table: "PlanTypes",
                type: "text",
                nullable: false,
                defaultValue: "");

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
             

            migrationBuilder.DropColumn(
                name: "KeyFeature1",
                table: "PlanTypes");

            migrationBuilder.DropColumn(
                name: "KeyFeature2",
                table: "PlanTypes");

            migrationBuilder.DropColumn(
                name: "KeyFeature3",
                table: "PlanTypes");

            migrationBuilder.CreateTable(
                name: "KeyFeatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlanTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeyFeatures_PlanTypes_PlanTypeId",
                        column: x => x.PlanTypeId,
                        principalTable: "PlanTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            
            migrationBuilder.CreateIndex(
                name: "IX_KeyFeatures_PlanTypeId",
                table: "KeyFeatures",
                column: "PlanTypeId");
        }
    }
}
