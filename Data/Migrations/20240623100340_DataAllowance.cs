using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class DataAllowance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
 
            migrationBuilder.AddColumn<int>(
                name: "DataAllowance",
                table: "PlanTypes",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlanName",
                table: "Plans",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "PhoneLine",
                table: "Plans",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SetUpCharge",
                table: "Plans",
                type: "numeric",
                nullable: true);

           

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "DataAllowance",
                table: "PlanTypes");

            migrationBuilder.DropColumn(
                name: "PhoneLine",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "SetUpCharge",
                table: "Plans");

            migrationBuilder.AlterColumn<string>(
                name: "PlanName",
                table: "Plans",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            
        }
    }
}
