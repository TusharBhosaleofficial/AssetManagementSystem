using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AssetManagementSystem.Data;
using AssetManagementSystem.Models;

namespace AssetManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssetsController : ControllerBase
{
    private readonly AssetDbContext _context;

    public AssetsController(AssetDbContext context)
    {
        _context = context;
    }

    // GET: api/assets
    [HttpGet]
    public async Task<IActionResult> GetAllAssets()
    {
        var assets = await _context.Assets.ToListAsync();
        return Ok(assets);
    }

    // GET: api/assets/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAssetById(int id)
    {
        var asset = await _context.Assets.FindAsync(id);

        if (asset == null)
            return NotFound("Asset not found");

        return Ok(asset);
    }

    // POST: api/assets
    [HttpPost]
    public async Task<IActionResult> CreateAsset(Asset asset)
    {
        asset.Status = "Unassigned";

        _context.Assets.Add(asset);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAssetById),
            new { id = asset.AssetId }, asset);
    }

    // PUT: api/assets/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsset(int id, Asset asset)
    {
        if (id != asset.AssetId)
            return BadRequest("Asset ID mismatch");

        var existingAsset = await _context.Assets.FindAsync(id);
        if (existingAsset == null)
            return NotFound("Asset not found");

        existingAsset.AssetName = asset.AssetName;
        existingAsset.AssetType = asset.AssetType;
        existingAsset.SerialNumber = asset.SerialNumber;
        existingAsset.PurchaseDate = asset.PurchaseDate;
        existingAsset.Price = asset.Price;

        await _context.SaveChangesAsync();
        return Ok(existingAsset);
    }

    // DELETE: api/assets/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsset(int id)
    {
        var asset = await _context.Assets.FindAsync(id);
        if (asset == null)
            return NotFound("Asset not found");

        _context.Assets.Remove(asset);
        await _context.SaveChangesAsync();

        return Ok("Asset deleted successfully");
    }
    // GET: api/Assets/employee/1
    [HttpGet("employee/{employeeId}")]
    public async Task<IActionResult> GetAssetsByEmployee(int employeeId)
    {
        var assets = await _context.AssetAssignments
            .Where(a => a.EmployeeId == employeeId)
            .Join(_context.Assets,
                  a => a.AssetId,
                  asset => asset.AssetId,
                  (a, asset) => asset)
            .ToListAsync();

        return Ok(assets);
    }


}
