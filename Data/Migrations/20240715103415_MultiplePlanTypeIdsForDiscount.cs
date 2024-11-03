using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class MultiplePlanTypeIdsForDiscount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            

            migrationBuilder.DropColumn(
                name: "PlanTypeId",
                table: "Discounts");

            migrationBuilder.AddColumn<Guid>(
                name: "DiscountId",
                table: "PlanTypes",
                type: "uuid",
                nullable: true);

           
            migrationBuilder.CreateIndex(
                name: "IX_PlanTypes_DiscountId",
                table: "PlanTypes",
                column: "DiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanTypes_Discounts_DiscountId",
                table: "PlanTypes",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanTypes_Discounts_DiscountId",
                table: "PlanTypes");

            migrationBuilder.DropIndex(
                name: "IX_PlanTypes_DiscountId",
                table: "PlanTypes");

             
            migrationBuilder.DropColumn(
                name: "DiscountId",
                table: "PlanTypes");

            migrationBuilder.AddColumn<Guid>(
                name: "PlanTypeId",
                table: "Discounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

           
            migrationBuilder.CreateIndex(
                name: "IX_Discounts_PlanTypeId",
                table: "Discounts",
                column: "PlanTypeId");

        }
    }
}
