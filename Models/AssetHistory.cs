namespace AssetManagementSystem.Models;

public class AssetHistory
{
    public int HistoryId { get; set; }
    public int AssetId { get; set; }
    public int EmployeeId { get; set; }
    public string? Action { get; set; }
    public DateTime ActionDate { get; set; }
}
