using AssetManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementSystem.Data;

public class AssetDbContext : DbContext
{
    public AssetDbContext(DbContextOptions<AssetDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ================= PRIMARY KEYS =================
        modelBuilder.Entity<AssetAssignment>()
            .HasKey(a => a.AssignmentId);

        modelBuilder.Entity<AssetHistory>()
            .HasKey(h => h.HistoryId);

        modelBuilder.Entity<AssetRequest>()
            .HasKey(r => r.RequestId);

        modelBuilder.Entity<User>()
            .HasKey(u => u.UserId);


        modelBuilder.Entity<User>().HasData(
            new User { UserId = 1, Username = "admin", Password = "admin123", Role = "Admin", EmployeeId = null },

            new User { UserId = 2, Username = "tushar", Password = "tushar123", Role = "Employee", EmployeeId = 1 },
            new User { UserId = 3, Username = "amit", Password = "amit123", Role = "Employee", EmployeeId = 2 },
            new User { UserId = 4, Username = "sneha", Password = "sneha123", Role = "Employee", EmployeeId = 3 },
            new User { UserId = 5, Username = "pooja", Password = "pooja123", Role = "Employee", EmployeeId = 4 },
            new User { UserId = 6, Username = "ankit", Password = "ankit123", Role = "Employee", EmployeeId = 5 }
        );


        // ================= EMPLOYEES (15) =================
        modelBuilder.Entity<Employee>().HasData(
            new Employee { EmployeeId = 1, Name = "Tushar Bhosale", Email = "tushar@pratiti.com", Department = "IT" },
            new Employee { EmployeeId = 2, Name = "Amit Verma", Email = "rahul@company.com", Department = "HR" },
            new Employee { EmployeeId = 3, Name = "Sneha Patil", Email = "sneha@company.com", Department = "Finance" },
            new Employee { EmployeeId = 4, Name = "Pooja Singh", Email = "pooja@company.com", Department = "Admin" },
            new Employee { EmployeeId = 5, Name = "Ankit Jain", Email = "ankit@company.com", Department = "IT" },
            new Employee { EmployeeId = 6, Name = "Neha Kulkarni", Email = "neha@company.com", Department = "HR" },
            new Employee { EmployeeId = 7, Name = "Rohit Mehta", Email = "rohit@company.com", Department = "Support" },
            new Employee { EmployeeId = 8, Name = "Kiran Deshpande", Email = "kiran@company.com", Department = "Finance" },
            new Employee { EmployeeId = 9, Name = "Suresh Iyer", Email = "suresh@company.com", Department = "IT" },
            new Employee { EmployeeId = 10, Name = "Priya Nair", Email = "priya@company.com", Department = "HR" },
            new Employee { EmployeeId = 11, Name = "Vikas Gupta", Email = "vikas@company.com", Department = "Admin" },
            new Employee { EmployeeId = 12, Name = "Manoj Pawar", Email = "manoj@company.com", Department = "Support" },
            new Employee { EmployeeId = 13, Name = "Aarti Joshi", Email = "aarti@company.com", Department = "Finance" },
            new Employee { EmployeeId = 14, Name = "Deepak Rao", Email = "deepak@company.com", Department = "IT" },
            new Employee { EmployeeId = 15, Name = "Nikhil Patil", Email = "nikhil@company.com", Department = "HR" },
            new Employee { EmployeeId = 16, Name = "Riya Kulkarni", Email = "riya@company.com", Department = "IT" },
            new Employee { EmployeeId = 17, Name = "Aditya Joshi", Email = "aditya@company.com", Department = "Finance" },
            new Employee { EmployeeId = 18, Name = "Meenal Desai", Email = "meenal@company.com", Department = "HR" },
            new Employee { EmployeeId = 19, Name = "Sanket Patil", Email = "sanket@company.com", Department = "Support" },
            new Employee { EmployeeId = 20, Name = "Rohini Shah", Email = "rohini@company.com", Department = "Admin" }

        );

        // ================= ASSETS (25) =================
        modelBuilder.Entity<Asset>().HasData(
            new Asset { AssetId = 1, AssetName = "Dell Laptop", AssetType = "Laptop", SerialNumber = "DL-001", PurchaseDate = new DateTime(2023, 1, 1), Price = 60000, Status = "Unassigned" },
            new Asset { AssetId = 2, AssetName = "HP Laptop", AssetType = "Laptop", SerialNumber = "HP-002", PurchaseDate = new DateTime(2023, 2, 1), Price = 58000, Status = "Unassigned" },
            new Asset { AssetId = 3, AssetName = "Lenovo Laptop", AssetType = "Laptop", SerialNumber = "LN-003", PurchaseDate = new DateTime(2023, 3, 1), Price = 62000, Status = "Unassigned" },
            new Asset { AssetId = 4, AssetName = "MacBook Air", AssetType = "Laptop", SerialNumber = "MB-004", PurchaseDate = new DateTime(2023, 4, 1), Price = 95000, Status = "Unassigned" },
            new Asset { AssetId = 5, AssetName = "Dell Monitor", AssetType = "Monitor", SerialNumber = "DM-005", PurchaseDate = new DateTime(2023, 1, 15), Price = 15000, Status = "Unassigned" },
            // 👉 (You can extend till 25 later, this is enough to pass migration)

            new Asset { AssetId = 6, AssetName = "HP Monitor", AssetType = "Monitor", SerialNumber = "HM-006", PurchaseDate = DateTime.Parse("2023-02-15"), Price = 14000, Status = "Unassigned" },
            new Asset { AssetId = 7, AssetName = "Logitech Mouse", AssetType = "Mouse", SerialNumber = "LM-007", PurchaseDate = DateTime.Parse("2023-03-10"), Price = 1200, Status = "Unassigned" },
            new Asset { AssetId = 8, AssetName = "Dell Keyboard", AssetType = "Keyboard", SerialNumber = "DK-008", PurchaseDate = DateTime.Parse("2023-03-12"), Price = 1800, Status = "Unassigned" },
            new Asset { AssetId = 9, AssetName = "iPhone", AssetType = "Mobile", SerialNumber = "IP-009", PurchaseDate = DateTime.Parse("2023-05-01"), Price = 75000, Status = "Unassigned" },
            new Asset { AssetId = 10, AssetName = "Samsung Phone", AssetType = "Mobile", SerialNumber = "SP-010", PurchaseDate = DateTime.Parse("2023-05-10"), Price = 42000, Status = "Unassigned" },
            new Asset { AssetId = 11, AssetName = "Acer Laptop", AssetType = "Laptop", SerialNumber = "AC-011", PurchaseDate = DateTime.Parse("2023-06-01"), Price = 55000, Status = "Unassigned" },
            new Asset { AssetId = 12, AssetName = "Asus Laptop", AssetType = "Laptop", SerialNumber = "AS-012", PurchaseDate = DateTime.Parse("2023-06-10"), Price = 60000, Status = "Unassigned" },
            new Asset { AssetId = 13, AssetName = "LG Monitor", AssetType = "Monitor", SerialNumber = "LG-013", PurchaseDate = DateTime.Parse("2023-06-15"), Price = 16000, Status = "Unassigned" },
            new Asset { AssetId = 14, AssetName = "Wireless Keyboard", AssetType = "Keyboard", SerialNumber = "WK-014", PurchaseDate = DateTime.Parse("2023-07-01"), Price = 2200, Status = "Unassigned" },
            new Asset { AssetId = 15, AssetName = "Wireless Mouse", AssetType = "Mouse", SerialNumber = "WM-015", PurchaseDate = DateTime.Parse("2023-07-02"), Price = 1500, Status = "Unassigned" },
            new Asset { AssetId = 16, AssetName = "iPad", AssetType = "Tablet", SerialNumber = "IP-016", PurchaseDate = DateTime.Parse("2023-07-10"), Price = 50000, Status = "Unassigned" },
            new Asset { AssetId = 17, AssetName = "Samsung Tablet", AssetType = "Tablet", SerialNumber = "ST-017", PurchaseDate = DateTime.Parse("2023-07-15"), Price = 42000, Status = "Unassigned" },
            new Asset { AssetId = 18, AssetName = "HP Printer", AssetType = "Printer", SerialNumber = "HP-018", PurchaseDate = DateTime.Parse("2023-08-01"), Price = 18000, Status = "Unassigned" },
            new Asset { AssetId = 19, AssetName = "Canon Printer", AssetType = "Printer", SerialNumber = "CP-019", PurchaseDate = DateTime.Parse("2023-08-05"), Price = 20000, Status = "Unassigned" },
            new Asset { AssetId = 20, AssetName = "Projector", AssetType = "Projector", SerialNumber = "PJ-020", PurchaseDate = DateTime.Parse("2023-08-10"), Price = 55000, Status = "Unassigned" },
            new Asset { AssetId = 21, AssetName = "Router", AssetType = "Network", SerialNumber = "RT-021", PurchaseDate = DateTime.Parse("2023-08-15"), Price = 8000, Status = "Unassigned" },
            new Asset { AssetId = 22, AssetName = "Switch", AssetType = "Network", SerialNumber = "SW-022", PurchaseDate = DateTime.Parse("2023-08-20"), Price = 12000, Status = "Unassigned" },
            new Asset { AssetId = 23, AssetName = "External HDD", AssetType = "Storage", SerialNumber = "HD-023", PurchaseDate = DateTime.Parse("2023-09-01"), Price = 7000, Status = "Unassigned" },
            new Asset { AssetId = 24, AssetName = "SSD Drive", AssetType = "Storage", SerialNumber = "SD-024", PurchaseDate = DateTime.Parse("2023-09-05"), Price = 9000, Status = "Unassigned" },
            new Asset { AssetId = 25, AssetName = "Webcam", AssetType = "Camera", SerialNumber = "WC-025", PurchaseDate = DateTime.Parse("2023-09-10"), Price = 4000, Status = "Unassigned" },
            new Asset { AssetId = 26, AssetName = "Headset", AssetType = "Audio", SerialNumber = "HS-026", PurchaseDate = DateTime.Parse("2023-09-12"), Price = 3500, Status = "Unassigned" },
            new Asset { AssetId = 27, AssetName = "Speakers", AssetType = "Audio", SerialNumber = "SP-027", PurchaseDate = DateTime.Parse("2023-09-15"), Price = 4500, Status = "Unassigned" },
            new Asset { AssetId = 28, AssetName = "UPS", AssetType = "Power", SerialNumber = "UP-028", PurchaseDate = DateTime.Parse("2023-09-20"), Price = 11000, Status = "Unassigned" },
            new Asset { AssetId = 29, AssetName = "Scanner", AssetType = "Scanner", SerialNumber = "SC-029", PurchaseDate = DateTime.Parse("2023-09-25"), Price = 13000, Status = "Unassigned" },
            new Asset { AssetId = 30, AssetName = "Biometric Device", AssetType = "Security", SerialNumber = "BD-030", PurchaseDate = DateTime.Parse("2023-09-30"), Price = 9000, Status = "Unassigned" }
        );
    }

    public DbSet<Asset> Assets { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<AssetAssignment> AssetAssignments { get; set; }
    public DbSet<AssetHistory> AssetHistories { get; set; }
    public DbSet<AssetRequest> AssetRequests { get; set; }
}
