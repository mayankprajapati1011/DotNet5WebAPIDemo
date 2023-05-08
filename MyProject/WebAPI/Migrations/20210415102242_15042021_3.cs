using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class _15042021_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "CreatedDate", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[] { 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Local), null, null, "India" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
