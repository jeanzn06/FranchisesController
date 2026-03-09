using Microsoft.AspNetCore.Mvc;
using Franchise.Api.Data;
using Franchise.Api.Models;

namespace Franchise.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BranchesController : ControllerBase
{
    private readonly AppDbContext _context;

    public BranchesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBranch(Branch branch)
    {
        var franchise = await _context.Franchises.FindAsync(branch.FranchiseId);

        if (franchise == null)
        {
            return NotFound("Franchise not found");
        }

        _context.Branches.Add(branch);
        await _context.SaveChangesAsync();

        return Ok(branch);
    }
}