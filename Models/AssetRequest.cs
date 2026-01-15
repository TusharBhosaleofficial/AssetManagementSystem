namespace AssetManagementSystem.Models;

public class AssetRequest
{
    public int RequestId { get; set; }
    public int EmployeeId { get; set; }
    public string? AssetType { get; set; }
    public DateTime RequestDate { get; set; }
    public string? Status { get; set; } // Pending / Approved / Rejected


}
