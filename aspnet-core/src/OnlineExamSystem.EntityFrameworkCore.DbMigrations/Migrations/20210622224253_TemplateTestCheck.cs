using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineExamSystem.Migrations
{
    public partial class TemplateTestCheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TemplateId",
                table: "AppOES_Test",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "AppOES_Test");
        }
    }
}
