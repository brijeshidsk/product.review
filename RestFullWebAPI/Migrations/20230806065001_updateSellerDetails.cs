using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestFullWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateSellerDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SellerContact",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SellerEmail",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SellerName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellerContact",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SellerEmail",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SellerName",
                table: "Products");
        }
    }
}
