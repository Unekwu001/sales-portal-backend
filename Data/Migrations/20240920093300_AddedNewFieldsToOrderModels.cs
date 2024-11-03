using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewFieldsToOrderModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSavedAndReadyForPayment",
                table: "SmeOrders",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfMonthsPaidFor",
                table: "SmeOrders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SetUpCharge",
                table: "SmeOrders",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCostOfPlanType",
                table: "SmeOrders",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPaymentExpected",
                table: "SmeOrders",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSavedAndReadyForPayment",
                table: "ResidentialOrders",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfMonthsPaidFor",
                table: "ResidentialOrders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SetUpCharge",
                table: "ResidentialOrders",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCostOfPlanType",
                table: "ResidentialOrders",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPaymentExpected",
                table: "ResidentialOrders",
                type: "numeric",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSavedAndReadyForPayment",
                table: "SmeOrders");

            migrationBuilder.DropColumn(
                name: "NumberOfMonthsPaidFor",
                table: "SmeOrders");

            migrationBuilder.DropColumn(
                name: "SetUpCharge",
                table: "SmeOrders");

            migrationBuilder.DropColumn(
                name: "TotalCostOfPlanType",
                table: "SmeOrders");

            migrationBuilder.DropColumn(
                name: "TotalPaymentExpected",
                table: "SmeOrders");

            migrationBuilder.DropColumn(
                name: "IsSavedAndReadyForPayment",
                table: "ResidentialOrders");

            migrationBuilder.DropColumn(
                name: "NumberOfMonthsPaidFor",
                table: "ResidentialOrders");

            migrationBuilder.DropColumn(
                name: "SetUpCharge",
                table: "ResidentialOrders");

            migrationBuilder.DropColumn(
                name: "TotalCostOfPlanType",
                table: "ResidentialOrders");

            migrationBuilder.DropColumn(
                name: "TotalPaymentExpected",
                table: "ResidentialOrders");
        }
    }
}
