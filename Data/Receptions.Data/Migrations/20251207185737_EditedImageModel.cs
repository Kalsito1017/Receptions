using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Receptions.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditedImageModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Images",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Images");
        }
    }
}
