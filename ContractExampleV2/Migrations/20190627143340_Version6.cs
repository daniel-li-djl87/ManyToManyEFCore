using Microsoft.EntityFrameworkCore.Migrations;

namespace ContractExampleV2.Migrations
{
    public partial class Version6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPost_Blogs_BlogId",
                table: "BlogPost");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPost_Posts_PostId",
                table: "BlogPost");

            migrationBuilder.DropIndex(
                name: "IX_Authors_PostId",
                table: "Authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogPost",
                table: "BlogPost");

            migrationBuilder.RenameTable(
                name: "BlogPost",
                newName: "BlogPosts");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPost_PostId",
                table: "BlogPosts",
                newName: "IX_BlogPosts_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogPosts",
                table: "BlogPosts",
                columns: new[] { "BlogId", "PostId" });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_PostId",
                table: "Authors",
                column: "PostId",
                unique: true,
                filter: "[PostId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_Blogs_BlogId",
                table: "BlogPosts",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_Posts_PostId",
                table: "BlogPosts",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Blogs_BlogId",
                table: "BlogPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Posts_PostId",
                table: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_Authors_PostId",
                table: "Authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogPosts",
                table: "BlogPosts");

            migrationBuilder.RenameTable(
                name: "BlogPosts",
                newName: "BlogPost");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPosts_PostId",
                table: "BlogPost",
                newName: "IX_BlogPost_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogPost",
                table: "BlogPost",
                columns: new[] { "BlogId", "PostId" });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_PostId",
                table: "Authors",
                column: "PostId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPost_Blogs_BlogId",
                table: "BlogPost",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPost_Posts_PostId",
                table: "BlogPost",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
