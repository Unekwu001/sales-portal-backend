using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class smeAndResidentialupdate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Smes_ContactPersonEmail",
                table: "Smes");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        { 

            migrationBuilder.CreateIndex(
                name: "IX_Smes_ContactPersonEmail",
                table: "Smes",
                column: "ContactPersonEmail",
                unique: true);
        }
    }
}
