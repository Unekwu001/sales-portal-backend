using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class discountPropAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "SmeOrders",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "ResidentialOrders",
                type: "numeric",
                nullable: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "SmeOrders");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "ResidentialOrders");

           
        }
    }
}
