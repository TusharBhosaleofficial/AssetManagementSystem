namespace AssetManagementSystem.Models;

public class Asset
{
    public int AssetId { get; set; }
    public string? AssetName { get; set; }
    public string? AssetType { get; set; }
    public string? SerialNumber { get; set; }
    public DateTime PurchaseDate { get; set; }
    public decimal Price { get; set; }
    public string? Status { get; set; } // Assigned / Unassigned
}
