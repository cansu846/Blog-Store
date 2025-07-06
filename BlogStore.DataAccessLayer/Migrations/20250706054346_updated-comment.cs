using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogStore.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class updatedcomment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "ToxicityScore",
                table: "Comments",
                type: "real",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToxicityScore",
                table: "Comments");
        }
    }
}
