using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganizationMgtSys.Migrations
{
    /// <inheritdoc />
    public partial class chhangestaffmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Role_RoleId",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Staff_RoleId",
                table: "Staff");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Staff",
                newName: "RoleID");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Staff");

            migrationBuilder.RenameColumn(
                name: "RoleID",
                table: "Staff",
                newName: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_RoleId",
                table: "Staff",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Role_RoleId",
                table: "Staff",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
