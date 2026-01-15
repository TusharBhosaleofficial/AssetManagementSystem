using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AssetManagementSystem.Data;

namespace AssetManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssetHistoryController : ControllerBase
{
    private readonly AssetDbContext _context;

    public AssetHistoryController(AssetDbContext context)
    {
        _context = context;
    }

    // GET: api/AssetHistory
    [HttpGet]
    public async Task<IActionResult> GetAllHistory()
    {
        var history = await _context.AssetHistories
            .OrderByDescending(h => h.ActionDate)
            .ToListAsync();

        return Ok(history);
    }

    // GET: api/AssetHistory/asset/1
    [HttpGet("asset/{assetId}")]
    public async Task<IActionResult> GetHistoryByAsset(int assetId)
    {
        var history = await _context.AssetHistories
            .Where(h => h.AssetId == assetId)
            .ToListAsync();

        return Ok(history);
    }
}
