using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICS_Project.Db.Migrations
{
    public partial class removebackrelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Teams_TeamId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "UserTeamEntity");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Posts",
                newName: "TeamEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_TeamId",
                table: "Posts",
                newName: "IX_Posts_TeamEntityId");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Comments",
                newName: "PostEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                newName: "IX_Comments_PostEntityId");

            migrationBuilder.AddColumn<Guid>(
                name: "TeamEntityId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AdminId",
                table: "Teams",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeamEntityId",
                table: "Users",
                column: "TeamEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_AdminId",
                table: "Teams",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostEntityId",
                table: "Comments",
                column: "PostEntityId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Teams_TeamEntityId",
                table: "Posts",
                column: "TeamEntityId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Users_AdminId",
                table: "Teams",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Teams_TeamEntityId",
                table: "Users",
                column: "TeamEntityId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostEntityId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Teams_TeamEntityId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Users_AdminId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Teams_TeamEntityId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TeamEntityId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Teams_AdminId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeamEntityId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "TeamEntityId",
                table: "Posts",
                newName: "TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_TeamEntityId",
                table: "Posts",
                newName: "IX_Posts_TeamId");

            migrationBuilder.RenameColumn(
                name: "PostEntityId",
                table: "Comments",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_PostEntityId",
                table: "Comments",
                newName: "IX_Comments_PostId");

            migrationBuilder.CreateTable(
                name: "UserTeamEntity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    TeamId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTeamEntity", x => new { x.UserId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_UserTeamEntity_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTeamEntity_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTeamEntity_TeamId",
                table: "UserTeamEntity",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Teams_TeamId",
                table: "Posts",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
