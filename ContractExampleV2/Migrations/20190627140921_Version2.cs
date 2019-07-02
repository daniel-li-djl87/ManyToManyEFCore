using Microsoft.EntityFrameworkCore.Migrations;

namespace ContractExampleV2.Migrations
{
    public partial class Version2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPost_Posts_PostId",
                table: "BlogPost");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPost_Posts_PostId",
                table: "BlogPost",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPost_Posts_PostId",
                table: "BlogPost");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPost_Posts_PostId",
                table: "BlogPost",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
