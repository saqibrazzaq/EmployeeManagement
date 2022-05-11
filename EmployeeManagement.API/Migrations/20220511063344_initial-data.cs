using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.API.Migrations
{
    public partial class initialdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "CompanyId", "Address", "Country", "Name" },
                values: new object[] { new Guid("50575e92-4a29-4557-9a4b-8a96278a6dbe"), "House 498, Street 105, Model Town, Humak, Islamabad", "Pakistan", "IT_Solutions Ltd" });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "CompanyId", "Address", "Country", "Name" },
                values: new object[] { new Guid("c65761ae-89fa-4c5c-98b6-4f55eb454f59"), "House 1228i, Usman Block, Bahria Phase 8, Rawalpindi", "Pakistan", "Admin_Solutions Ltd" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[] { new Guid("3070e5f0-90a6-4ccd-82ca-dd437e1ba295"), 41, new Guid("50575e92-4a29-4557-9a4b-8a96278a6dbe"), "Saqib Razzaq", "CEO" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[] { new Guid("b5279d7a-d4ae-42a7-871c-7997ab9bb2a2"), 11, new Guid("c65761ae-89fa-4c5c-98b6-4f55eb454f59"), "Shaheer Saqib", "CEO" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[] { new Guid("c4ca2c04-0f10-4324-992f-33e41e9f006e"), 38, new Guid("50575e92-4a29-4557-9a4b-8a96278a6dbe"), "Rabia Basri", "Director" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: new Guid("3070e5f0-90a6-4ccd-82ca-dd437e1ba295"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: new Guid("b5279d7a-d4ae-42a7-871c-7997ab9bb2a2"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: new Guid("c4ca2c04-0f10-4324-992f-33e41e9f006e"));

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "CompanyId",
                keyValue: new Guid("50575e92-4a29-4557-9a4b-8a96278a6dbe"));

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "CompanyId",
                keyValue: new Guid("c65761ae-89fa-4c5c-98b6-4f55eb454f59"));
        }
    }
}
