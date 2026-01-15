using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AssetManagementSystem.Data;
using AssetManagementSystem.Models;

namespace AssetManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssetAssignmentsController : ControllerBase
{
    private readonly AssetDbContext _context;

    public AssetAssignmentsController(AssetDbContext context)
    {
        _context = context;
    }

    // POST: api/AssetAssignments/assign
    [HttpPost("assign")]
    public async Task<IActionResult> AssignAsset(int assetId, int employeeId)
    {
        // 1. Check asset exists
        var asset = await _context.Assets.FindAsync(assetId);
        if (asset == null)
            return NotFound("Asset not found");

        // 2. Check employee exists
        var employee = await _context.Employees.FindAsync(employeeId);
        if (employee == null)
            return NotFound("Employee not found");

        // 3. Prevent double assignment
        if (asset.Status == "Assigned")
            return BadRequest("Asset is already assigned");

        // 4. Assign asset
        asset.Status = "Assigned";

        var assignment = new AssetAssignment
        {
            AssetId = assetId,
            EmployeeId = employeeId,
            AssignedDate = DateTime.UtcNow
        };

        _context.AssetAssignments.Add(assignment);

        // 5. Save history
        var history = new AssetHistory
        {
            AssetId = assetId,
            EmployeeId = employeeId,
            Action = "Assigned",
            ActionDate = DateTime.UtcNow
        };

        _context.AssetHistories.Add(history);

        await _context.SaveChangesAsync();

        return Ok(new { message = "Asset assigned successfully" });
    }

    // POST: api/AssetAssignments/unassign
    [HttpPost("unassign")]
    public async Task<IActionResult> UnassignAsset(int assetId)
    {
        // 1. Check asset exists
        var asset = await _context.Assets.FindAsync(assetId);
        if (asset == null)
            return NotFound("Asset not found");

        // 2. Check asset is assigned
        if (asset.Status != "Assigned")
            return BadRequest("Asset is not assigned");

        // 3. Unassign asset
        asset.Status = "Unassigned";

        // 4. Save history
        var history = new AssetHistory
        {
            AssetId = assetId,
            EmployeeId = 0, // no employee during unassign
            Action = "Unassigned",
            ActionDate = DateTime.UtcNow
        };

        _context.AssetHistories.Add(history);

        await _context.SaveChangesAsync();

        return Ok(new { message = "Asset unassigned successfully" });
    }
}
