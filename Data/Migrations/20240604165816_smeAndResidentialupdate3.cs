using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class smeAndResidentialupdate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {  
            

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "SmeBillingDetails");

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        { 
            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "SmeBillingDetails",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
  
        }
    }
}
