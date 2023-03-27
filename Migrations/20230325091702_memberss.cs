using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cv.Migrations
{
    public partial class memberss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "MemberId",
                table: "Education",
                type: "smallint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Education_MemberId",
                table: "Education",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Education_Member_MemberId",
                table: "Education",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Education_Member_MemberId",
                table: "Education");

            migrationBuilder.DropIndex(
                name: "IX_Education_MemberId",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Education");
        }
    }
}
