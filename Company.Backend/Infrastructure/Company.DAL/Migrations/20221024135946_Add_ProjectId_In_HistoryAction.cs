using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company.DAL.Migrations
{
    public partial class Add_ProjectId_In_HistoryAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryActions_Projects_ProjectEntityId",
                table: "HistoryActions");

            migrationBuilder.RenameColumn(
                name: "ProjectEntityId",
                table: "HistoryActions",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryActions_ProjectEntityId",
                table: "HistoryActions",
                newName: "IX_HistoryActions_ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryActions_Projects_ProjectId",
                table: "HistoryActions",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryActions_Projects_ProjectId",
                table: "HistoryActions");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "HistoryActions",
                newName: "ProjectEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryActions_ProjectId",
                table: "HistoryActions",
                newName: "IX_HistoryActions_ProjectEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryActions_Projects_ProjectEntityId",
                table: "HistoryActions",
                column: "ProjectEntityId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
