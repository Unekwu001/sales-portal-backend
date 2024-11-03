using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class adjustedDiscountStatesTolistOfStrings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropColumn(
                name: "City",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Discounts");

            migrationBuilder.AddColumn<string[]>(
                name: "Cities",
                table: "Discounts",
                type: "text[]",
                maxLength: 255,
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<string[]>(
                name: "States",
                table: "Discounts",
                type: "text[]",
                maxLength: 255,
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<string[]>(
                name: "Streets",
                table: "Discounts",
                type: "text[]",
                maxLength: 255,
                nullable: false,
                defaultValue: new string[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cities",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "States",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "Streets",
                table: "Discounts");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Discounts",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Discounts",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Discounts",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

          
        }
    }
}
