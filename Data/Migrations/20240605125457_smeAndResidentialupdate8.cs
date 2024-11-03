using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class smeAndResidentialupdate8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<string>(
                name: "PaymentReferenceNumber",
                table: "SmeOrders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PaymentReferenceNumber",
                table: "ResidentialOrders",
                type: "text",
                nullable: false,
                defaultValue: "");

             
 
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        { 

            migrationBuilder.DropColumn(
                name: "PaymentReferenceNumber",
                table: "SmeOrders");

            migrationBuilder.DropColumn(
                name: "PaymentReferenceNumber",
                table: "ResidentialOrders");

        }
    }
}
