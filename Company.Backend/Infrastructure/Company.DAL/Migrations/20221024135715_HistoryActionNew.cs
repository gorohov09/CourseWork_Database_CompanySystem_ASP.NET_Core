using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company.DAL.Migrations
{
    public partial class HistoryActionNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryActionEntity_Projects_ProjectEntityId",
                table: "HistoryActionEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HistoryActionEntity",
                table: "HistoryActionEntity");

            migrationBuilder.RenameTable(
                name: "HistoryActionEntity",
                newName: "HistoryActions");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryActionEntity_ProjectEntityId",
                table: "HistoryActions",
                newName: "IX_HistoryActions_ProjectEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistoryActions",
                table: "HistoryActions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryActions_Projects_ProjectEntityId",
                table: "HistoryActions",
                column: "ProjectEntityId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryActions_Projects_ProjectEntityId",
                table: "HistoryActions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HistoryActions",
                table: "HistoryActions");

            migrationBuilder.RenameTable(
                name: "HistoryActions",
                newName: "HistoryActionEntity");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryActions_ProjectEntityId",
                table: "HistoryActionEntity",
                newName: "IX_HistoryActionEntity_ProjectEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistoryActionEntity",
                table: "HistoryActionEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryActionEntity_Projects_ProjectEntityId",
                table: "HistoryActionEntity",
                column: "ProjectEntityId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
