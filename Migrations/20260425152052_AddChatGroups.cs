using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecureCommunicationApp.Migrations
{
    /// <inheritdoc />
    public partial class AddChatGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_ChatGroupId",
                table: "GroupMembers",
                column: "ChatGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_UserId",
                table: "GroupMembers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMembers_ChatGroups_ChatGroupId",
                table: "GroupMembers",
                column: "ChatGroupId",
                principalTable: "ChatGroups",
                principalColumn: "ChatGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMembers_Users_UserId",
                table: "GroupMembers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupMembers_ChatGroups_ChatGroupId",
                table: "GroupMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupMembers_Users_UserId",
                table: "GroupMembers");

            migrationBuilder.DropIndex(
                name: "IX_GroupMembers_ChatGroupId",
                table: "GroupMembers");

            migrationBuilder.DropIndex(
                name: "IX_GroupMembers_UserId",
                table: "GroupMembers");
        }
    }
}
