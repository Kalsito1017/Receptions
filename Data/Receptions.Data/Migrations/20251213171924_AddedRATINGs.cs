using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Receptions.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedRATINGs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeRating_AspNetUsers_UserId",
                table: "RecipeRating");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeRating_Recipes_RecipeId",
                table: "RecipeRating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeRating",
                table: "RecipeRating");

            migrationBuilder.RenameTable(
                name: "RecipeRating",
                newName: "RecipeRatings");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeRating_UserId",
                table: "RecipeRatings",
                newName: "IX_RecipeRatings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeRating_RecipeId",
                table: "RecipeRatings",
                newName: "IX_RecipeRatings_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeRatings",
                table: "RecipeRatings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeRatings_AspNetUsers_UserId",
                table: "RecipeRatings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeRatings_Recipes_RecipeId",
                table: "RecipeRatings",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeRatings_AspNetUsers_UserId",
                table: "RecipeRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeRatings_Recipes_RecipeId",
                table: "RecipeRatings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeRatings",
                table: "RecipeRatings");

            migrationBuilder.RenameTable(
                name: "RecipeRatings",
                newName: "RecipeRating");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeRatings_UserId",
                table: "RecipeRating",
                newName: "IX_RecipeRating_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeRatings_RecipeId",
                table: "RecipeRating",
                newName: "IX_RecipeRating_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeRating",
                table: "RecipeRating",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeRating_AspNetUsers_UserId",
                table: "RecipeRating",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeRating_Recipes_RecipeId",
                table: "RecipeRating",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
