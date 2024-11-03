using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class smeAndResidentialupdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Residentials_Email",
                table: "Residentials");

            

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Smes",
                newName: "networkCoverageAddress");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Residentials",
                newName: "networkCoverageAddress");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Smes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Residentials",
                type: "boolean",
                nullable: false,
                defaultValue: false);

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Smes");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Residentials");

            migrationBuilder.RenameColumn(
                name: "networkCoverageAddress",
                table: "Smes",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "networkCoverageAddress",
                table: "Residentials",
                newName: "Address");

            

            migrationBuilder.CreateIndex(
                name: "IX_Residentials_Email",
                table: "Residentials",
                column: "Email",
                unique: true);
        }
    }
}
