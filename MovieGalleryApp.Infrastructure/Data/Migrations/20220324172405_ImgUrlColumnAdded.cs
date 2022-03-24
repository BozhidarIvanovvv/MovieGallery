using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieGalleryApp.Infrastructure.Data.Migrations
{
    public partial class ImgUrlColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Movies",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Movies");
        }
    }
}
