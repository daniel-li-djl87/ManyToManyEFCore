using Microsoft.EntityFrameworkCore.Migrations;

namespace ContractExampleV2.Migrations
{
    public partial class Version8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Authors_PostId",
                table: "Authors");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_PostId",
                table: "Authors",
                column: "PostId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Authors_PostId",
                table: "Authors");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_PostId",
                table: "Authors",
                column: "PostId",
                unique: true);
        }
    }
}
