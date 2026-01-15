namespace AssetManagementSystem.Models;

public class User
{
    public int UserId { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; } // Admin or Employee
    public int? EmployeeId { get; set; } // only for employee users
}

