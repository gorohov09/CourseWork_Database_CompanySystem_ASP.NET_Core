using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company.DAL.Migrations
{
    public partial class IsMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMaster",
                table: "EmployeesProjects",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMaster",
                table: "EmployeesProjects");
        }
    }
}
