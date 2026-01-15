namespace AssetManagementSystem.Models;

public class AssetAssignment
{
    public int AssignmentId { get; set; }  // PRIMARY KEY
    public int AssetId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime AssignedDate { get; set; }
}
