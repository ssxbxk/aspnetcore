using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreWeb.Migrations
{
    public partial class _060803 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_CreateUserId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_CreateUserId",
                table: "Roles");

            migrationBuilder.AddColumn<Guid>(
                name: "UserModelId",
                table: "Roles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UserModelId",
                table: "Roles",
                column: "UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_UserModelId",
                table: "Roles",
                column: "UserModelId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_UserModelId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_UserModelId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "Roles");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CreateUserId",
                table: "Roles",
                column: "CreateUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_CreateUserId",
                table: "Roles",
                column: "CreateUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
