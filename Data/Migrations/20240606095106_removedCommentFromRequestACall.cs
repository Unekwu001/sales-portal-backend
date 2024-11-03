using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class removedCommentFromRequestACall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
 

           

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "CallBackRequests");

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "CallBackRequests",
                type: "text",
                nullable: false,
                defaultValue: "");
 
        }
    }
}
