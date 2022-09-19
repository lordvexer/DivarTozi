using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iptb.DivarTozi.Migrations
{
    public partial class AddParentIdToDastebandi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "AppDastebandis",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "AppDastebandis");
        }
    }
}
