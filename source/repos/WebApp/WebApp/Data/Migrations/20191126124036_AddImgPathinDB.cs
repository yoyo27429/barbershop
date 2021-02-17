using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Data.Migrations
{
    public partial class AddImgPathinDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "Ads",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "Ads");
        }
    }
}
