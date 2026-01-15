using Microsoft.AspNetCore.Mvc;
using AssetManagementSystem.Data;

namespace AssetManagementSystem.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AssetDbContext _context;

    public AuthController(AssetDbContext context)
    {
        _context = context;
    }

    [HttpGet("users")]
    public IActionResult GetUsers()
    {
        return Ok(_context.Users.ToList());
    }


    [HttpPost("login")]
    public IActionResult Login(string username, string password)
    {
        var user = _context.Users
            .FirstOrDefault(u =>
                u.Username == username &&
                u.Password == password);

        if (user == null)
            return Unauthorized("Invalid credentials");

        return Ok(new
        {
            user.UserId,
            user.Username,
            user.Role,
            user.EmployeeId
        });
    }
}
