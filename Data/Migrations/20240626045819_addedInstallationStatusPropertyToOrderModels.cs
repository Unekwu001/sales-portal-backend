using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addedInstallationStatusPropertyToOrderModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<bool>(
                name: "HasRequestedInstallation",
                table: "SmeOrders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasRequestedInstallation",
                table: "ResidentialOrders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

         
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropColumn(
                name: "HasRequestedInstallation",
                table: "SmeOrders");

            migrationBuilder.DropColumn(
                name: "HasRequestedInstallation",
                table: "ResidentialOrders");

          
        }
    }
}
