using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.LeaveManagement.Persistence.Migrations
{
    public partial class SeedingLeaveTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "ID", "CreatedBy", "DateCreated", "DefaultDays", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { 1, "Configuration", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Configuration", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vacation" });

            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "ID", "CreatedBy", "DateCreated", "DefaultDays", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { 2, "Configuration", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "Configuration", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sick" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
