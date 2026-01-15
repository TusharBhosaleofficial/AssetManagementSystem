using Microsoft.AspNetCore.Mvc;
using AssetManagementSystem.Data;
using AssetManagementSystem.Models;

namespace AssetManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssetRequestsController : ControllerBase
{
    private readonly AssetDbContext _context;

    public AssetRequestsController(AssetDbContext context)
    {
        _context = context;
    }

    // EMPLOYEE: Request Asset
    [HttpPost]
    public async Task<IActionResult> RequestAsset(AssetRequest request)
    {
        request.RequestDate = DateTime.UtcNow;
        request.Status = "Pending";

        _context.AssetRequests.Add(request);
        await _context.SaveChangesAsync();

        return Ok("Asset request submitted");
    }

    // ADMIN: View all requests
    [HttpGet]
    public IActionResult GetAllRequests()
    {
        return Ok(_context.AssetRequests.ToList());
    }

    // ADMIN: Approve request
    [HttpPost("approve/{requestId}")]
    public async Task<IActionResult> ApproveRequest(int requestId, int assetId)
    {
        var request = await _context.AssetRequests.FindAsync(requestId);
        if (request == null)
            return NotFound("Request not found");

        var asset = await _context.Assets.FindAsync(assetId);
        if (asset == null)
            return NotFound("Asset not found");

        if (asset.Status == "Assigned")
            return BadRequest("Asset already assigned");

        // Assign asset
        asset.Status = "Assigned";

        _context.AssetAssignments.Add(new AssetAssignment
        {
            AssetId = assetId,
            EmployeeId = request.EmployeeId,
            AssignedDate = DateTime.UtcNow
        });

        _context.AssetHistories.Add(new AssetHistory
        {
            AssetId = assetId,
            EmployeeId = request.EmployeeId,
            Action = "Assigned",
            ActionDate = DateTime.UtcNow
        });

        request.Status = "Approved";

        await _context.SaveChangesAsync();

        return Ok("Request approved and asset assigned");
    }

    // ADMIN: Reject request
    [HttpPost("reject/{requestId}")]
    public async Task<IActionResult> RejectRequest(int requestId)
    {
        var request = await _context.AssetRequests.FindAsync(requestId);
        if (request == null)
            return NotFound("Request not found");

        request.Status = "Rejected";
        await _context.SaveChangesAsync();

        return Ok("Request rejected");
    }
}
