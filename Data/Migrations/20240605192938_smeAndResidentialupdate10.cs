using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class smeAndResidentialupdate10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             

            
 

            migrationBuilder.AlterColumn<string>(
                name: "PaymentReferenceNumber",
                table: "ResidentialOrders",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
 
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        { 
            
  
            migrationBuilder.AlterColumn<string>(
                name: "PaymentReferenceNumber",
                table: "ResidentialOrders",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
 
        }
    }
}
