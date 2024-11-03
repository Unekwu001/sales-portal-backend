using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addedAgentpropertyrModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<Guid>(
                name: "AgentId",
                table: "SmeOrders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AgentId",
                table: "ResidentialOrders",
                type: "text",
                nullable: true);

            
            migrationBuilder.CreateIndex(
                name: "IX_SmeOrders_AgentId",
                table: "SmeOrders",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialOrders_AgentId",
                table: "ResidentialOrders",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialOrders_Agents_AgentId",
                table: "ResidentialOrders",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SmeOrders_Agents_AgentId",
                table: "SmeOrders",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialOrders_Agents_AgentId",
                table: "ResidentialOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_SmeOrders_Agents_AgentId",
                table: "SmeOrders");

            migrationBuilder.DropIndex(
                name: "IX_SmeOrders_AgentId",
                table: "SmeOrders");

            migrationBuilder.DropIndex(
                name: "IX_ResidentialOrders_AgentId",
                table: "ResidentialOrders");

           

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "SmeOrders");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "ResidentialOrders");

            
        }
    }
}
