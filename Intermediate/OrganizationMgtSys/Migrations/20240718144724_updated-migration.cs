using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganizationMgtSys.Migrations
{
    /// <inheritdoc />
    public partial class updatedmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_Companies_CompanyId",
                table: "Role");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffCheckIns_Companies_CompanyId",
                table: "StaffCheckIns");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffCheckOuts_Companies_CompanyId",
                table: "StaffCheckOuts");

            migrationBuilder.DropIndex(
                name: "IX_StaffCheckOuts_CompanyId",
                table: "StaffCheckOuts");

            migrationBuilder.DropIndex(
                name: "IX_StaffCheckIns_CompanyId",
                table: "StaffCheckIns");

            migrationBuilder.DropIndex(
                name: "IX_Role_CompanyId",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "StaffCheckOuts");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "StaffCheckIns");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Role");

            migrationBuilder.CreateIndex(
                name: "IX_StaffCheckOuts_StaffId",
                table: "StaffCheckOuts",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffCheckIns_StaffId",
                table: "StaffCheckIns",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffCheckIns_Staff_StaffId",
                table: "StaffCheckIns",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffCheckOuts_Staff_StaffId",
                table: "StaffCheckOuts",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffCheckIns_Staff_StaffId",
                table: "StaffCheckIns");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffCheckOuts_Staff_StaffId",
                table: "StaffCheckOuts");

            migrationBuilder.DropIndex(
                name: "IX_StaffCheckOuts_StaffId",
                table: "StaffCheckOuts");

            migrationBuilder.DropIndex(
                name: "IX_StaffCheckIns_StaffId",
                table: "StaffCheckIns");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "StaffCheckOuts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "StaffCheckIns",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Role",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CompanyId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CompanyId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_StaffCheckOuts_CompanyId",
                table: "StaffCheckOuts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffCheckIns_CompanyId",
                table: "StaffCheckIns",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_CompanyId",
                table: "Role",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Companies_CompanyId",
                table: "Role",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffCheckIns_Companies_CompanyId",
                table: "StaffCheckIns",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffCheckOuts_Companies_CompanyId",
                table: "StaffCheckOuts",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
