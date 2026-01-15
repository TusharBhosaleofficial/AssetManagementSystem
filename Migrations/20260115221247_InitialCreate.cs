using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AssetManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetAssignments",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetAssignments", x => x.AssignmentId);
                });

            migrationBuilder.CreateTable(
                name: "AssetHistories",
                columns: table => new
                {
                    HistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetHistories", x => x.HistoryId);
                });

            migrationBuilder.CreateTable(
                name: "AssetRequests",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    AssetType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetRequests", x => x.RequestId);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    AssetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.AssetId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "AssetName", "AssetType", "Price", "PurchaseDate", "SerialNumber", "Status" },
                values: new object[,]
                {
                    { 1, "Dell Laptop", "Laptop", 60000m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DL-001", "Unassigned" },
                    { 2, "HP Laptop", "Laptop", 58000m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HP-002", "Unassigned" },
                    { 3, "Lenovo Laptop", "Laptop", 62000m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LN-003", "Unassigned" },
                    { 4, "MacBook Air", "Laptop", 95000m, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MB-004", "Unassigned" },
                    { 5, "Dell Monitor", "Monitor", 15000m, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "DM-005", "Unassigned" },
                    { 6, "HP Monitor", "Monitor", 14000m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "HM-006", "Unassigned" },
                    { 7, "Logitech Mouse", "Mouse", 1200m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "LM-007", "Unassigned" },
                    { 8, "Dell Keyboard", "Keyboard", 1800m, new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "DK-008", "Unassigned" },
                    { 9, "iPhone", "Mobile", 75000m, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IP-009", "Unassigned" },
                    { 10, "Samsung Phone", "Mobile", 42000m, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "SP-010", "Unassigned" },
                    { 11, "Acer Laptop", "Laptop", 55000m, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AC-011", "Unassigned" },
                    { 12, "Asus Laptop", "Laptop", 60000m, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "AS-012", "Unassigned" },
                    { 13, "LG Monitor", "Monitor", 16000m, new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "LG-013", "Unassigned" },
                    { 14, "Wireless Keyboard", "Keyboard", 2200m, new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "WK-014", "Unassigned" },
                    { 15, "Wireless Mouse", "Mouse", 1500m, new DateTime(2023, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "WM-015", "Unassigned" },
                    { 16, "iPad", "Tablet", 50000m, new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "IP-016", "Unassigned" },
                    { 17, "Samsung Tablet", "Tablet", 42000m, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST-017", "Unassigned" },
                    { 18, "HP Printer", "Printer", 18000m, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HP-018", "Unassigned" },
                    { 19, "Canon Printer", "Printer", 20000m, new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "CP-019", "Unassigned" },
                    { 20, "Projector", "Projector", 55000m, new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "PJ-020", "Unassigned" },
                    { 21, "Router", "Network", 8000m, new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "RT-021", "Unassigned" },
                    { 22, "Switch", "Network", 12000m, new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "SW-022", "Unassigned" },
                    { 23, "External HDD", "Storage", 7000m, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HD-023", "Unassigned" },
                    { 24, "SSD Drive", "Storage", 9000m, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "SD-024", "Unassigned" },
                    { 25, "Webcam", "Camera", 4000m, new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "WC-025", "Unassigned" },
                    { 26, "Headset", "Audio", 3500m, new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "HS-026", "Unassigned" },
                    { 27, "Speakers", "Audio", 4500m, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "SP-027", "Unassigned" },
                    { 28, "UPS", "Power", 11000m, new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "UP-028", "Unassigned" },
                    { 29, "Scanner", "Scanner", 13000m, new DateTime(2023, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC-029", "Unassigned" },
                    { 30, "Biometric Device", "Security", 9000m, new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "BD-030", "Unassigned" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Department", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "IT", "tushar@pratiti.com", "Tushar Bhosale" },
                    { 2, "HR", "rahul@company.com", "Amit Verma" },
                    { 3, "Finance", "sneha@company.com", "Sneha Patil" },
                    { 4, "Admin", "pooja@company.com", "Pooja Singh" },
                    { 5, "IT", "ankit@company.com", "Ankit Jain" },
                    { 6, "HR", "neha@company.com", "Neha Kulkarni" },
                    { 7, "Support", "rohit@company.com", "Rohit Mehta" },
                    { 8, "Finance", "kiran@company.com", "Kiran Deshpande" },
                    { 9, "IT", "suresh@company.com", "Suresh Iyer" },
                    { 10, "HR", "priya@company.com", "Priya Nair" },
                    { 11, "Admin", "vikas@company.com", "Vikas Gupta" },
                    { 12, "Support", "manoj@company.com", "Manoj Pawar" },
                    { 13, "Finance", "aarti@company.com", "Aarti Joshi" },
                    { 14, "IT", "deepak@company.com", "Deepak Rao" },
                    { 15, "HR", "nikhil@company.com", "Nikhil Patil" },
                    { 16, "IT", "riya@company.com", "Riya Kulkarni" },
                    { 17, "Finance", "aditya@company.com", "Aditya Joshi" },
                    { 18, "HR", "meenal@company.com", "Meenal Desai" },
                    { 19, "Support", "sanket@company.com", "Sanket Patil" },
                    { 20, "Admin", "rohini@company.com", "Rohini Shah" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "EmployeeId", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, null, "admin123", "Admin", "admin" },
                    { 2, 1, "tushar123", "Employee", "tushar" },
                    { 3, 2, "amit123", "Employee", "amit" },
                    { 4, 3, "sneha123", "Employee", "sneha" },
                    { 5, 4, "pooja123", "Employee", "pooja" },
                    { 6, 5, "ankit123", "Employee", "ankit" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetAssignments");

            migrationBuilder.DropTable(
                name: "AssetHistories");

            migrationBuilder.DropTable(
                name: "AssetRequests");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
