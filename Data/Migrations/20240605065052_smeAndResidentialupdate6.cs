using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class smeAndResidentialupdate6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ResidentialBillingDetails");

            migrationBuilder.DropTable(
                name: "SmeBillingDetails");

            migrationBuilder.DropTable(
                name: "Residentials");

            migrationBuilder.DropTable(
                name: "Smes");

             

            migrationBuilder.CreateTable(
                name: "ResidentialOrderBillingDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    LastName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    StreetName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    State = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ResidentialId = table.Column<string>(type: "text", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialOrderBillingDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmeOrderBillingDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactPersonFirstName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ContactPersonLastName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ContactPersonEmail = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ContactPersonPhoneNumber = table.Column<string>(type: "text", nullable: true),
                    CompanyStreetName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    State = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    SmeId = table.Column<string>(type: "text", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmeOrderBillingDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResidentialOrders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    LastName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    networkCoverageAddress = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    AlternativePhoneNumber = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Occupation = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    Nationality = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FlatNumber = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    HouseNumber = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    StreetName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    EstateName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    State = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    TypeOfBuilding = table.Column<string>(type: "text", nullable: true),
                    IsBillingAddressSameAsResidentialAddress = table.Column<string>(type: "character varying(1)", nullable: false),
                    ResidentialBillingDetailsId = table.Column<Guid>(type: "uuid", nullable: true),
                    PassportPhotograph = table.Column<string>(type: "text", nullable: true),
                    GovernmentId = table.Column<string>(type: "text", nullable: true),
                    UtilityBill = table.Column<string>(type: "text", nullable: true),
                    PlanTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsFormCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    PaymentStatus = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentialOrders_PlanTypes_PlanTypeId",
                        column: x => x.PlanTypeId,
                        principalTable: "PlanTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialOrders_ResidentialOrderBillingDetails_Residentia~",
                        column: x => x.ResidentialBillingDetailsId,
                        principalTable: "ResidentialOrderBillingDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SmeOrders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CompanyName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ContactPersonFirstName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ContactPersonLastName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ContactPersonEmail = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    networkCoverageAddress = table.Column<string>(type: "text", nullable: false),
                    TypeOfBusiness = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ContactPersonPhoneNumber = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ContactPersonAlternativePhoneNumber = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CompanyStreetName = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    City = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    State = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    TypeOfBuilding = table.Column<string>(type: "text", nullable: true),
                    IsBillingAddressSameAsResidentialAddress = table.Column<string>(type: "character varying(1)", nullable: false),
                    SmeBillingDetailsId = table.Column<Guid>(type: "uuid", nullable: true),
                    PassportPhotograph = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    LetterOfIntroduction = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    GovernmentId = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    UtilityBill = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CertificateOfIncorporation = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PlanTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsFormCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    PaymentStatus = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmeOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmeOrders_PlanTypes_PlanTypeId",
                        column: x => x.PlanTypeId,
                        principalTable: "PlanTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SmeOrders_SmeOrderBillingDetails_SmeBillingDetailsId",
                        column: x => x.SmeBillingDetailsId,
                        principalTable: "SmeOrderBillingDetails",
                        principalColumn: "Id");
                });

           

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialOrders_PlanTypeId",
                table: "ResidentialOrders",
                column: "PlanTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialOrders_ResidentialBillingDetailsId",
                table: "ResidentialOrders",
                column: "ResidentialBillingDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_SmeOrders_PlanTypeId",
                table: "SmeOrders",
                column: "PlanTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SmeOrders_SmeBillingDetailsId",
                table: "SmeOrders",
                column: "SmeBillingDetailsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResidentialOrders");

            migrationBuilder.DropTable(
                name: "SmeOrders");

            migrationBuilder.DropTable(
                name: "ResidentialOrderBillingDetails");

            migrationBuilder.DropTable(
                name: "SmeOrderBillingDetails");

            
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PlanTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusEnum = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Residentials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AlternativePhoneNumber = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Email = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    EstateName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    FirstName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    FlatNumber = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    GovernmentId = table.Column<string>(type: "text", nullable: true),
                    HouseNumber = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsBillingAddressSameAsResidentialAddress = table.Column<string>(type: "character varying(1)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Nationality = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Occupation = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    PassportPhotograph = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    PlanTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    State = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    StreetName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    TypeOfBuilding = table.Column<string>(type: "text", nullable: true),
                    UtilityBill = table.Column<string>(type: "text", nullable: true),
                    networkCoverageAddress = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residentials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Smes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CertificateOfIncorporation = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    City = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CompanyStreetName = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    ContactPersonAlternativePhoneNumber = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ContactPersonEmail = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ContactPersonFirstName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ContactPersonLastName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ContactPersonPhoneNumber = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GovernmentId = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsBillingAddressSameAsResidentialAddress = table.Column<string>(type: "character varying(1)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LetterOfIntroduction = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PassportPhotograph = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PlanTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    State = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    TypeOfBuilding = table.Column<string>(type: "text", nullable: true),
                    TypeOfBusiness = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    UtilityBill = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    networkCoverageAddress = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResidentialBillingDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    City = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Email = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    LastName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ResidentialId = table.Column<Guid>(type: "uuid", nullable: false),
                    State = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    StreetName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialBillingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentialBillingDetails_Residentials_ResidentialId",
                        column: x => x.ResidentialId,
                        principalTable: "Residentials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SmeBillingDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    City = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CompanyStreetName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ContactPersonEmail = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ContactPersonFirstName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ContactPersonLastName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ContactPersonPhoneNumber = table.Column<string>(type: "text", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SmeId = table.Column<Guid>(type: "uuid", nullable: false),
                    State = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmeBillingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmeBillingDetails_Smes_SmeId",
                        column: x => x.SmeId,
                        principalTable: "Smes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
 

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialBillingDetails_ResidentialId",
                table: "ResidentialBillingDetails",
                column: "ResidentialId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SmeBillingDetails_SmeId",
                table: "SmeBillingDetails",
                column: "SmeId",
                unique: true);
        }
    }
}
