using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Franchise.Api.Data;
using Franchise.Api.Models;

namespace Franchise.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FranchiseController : ControllerBase
{
    private readonly AppDbContext _context;

    public FranchiseController(AppDbContext context)
    {
        _context = context;
    }

    // Crear franquicia
    [HttpPost]
    public async Task<IActionResult> CreateFranchise(Models.Franchise franchise)
    {
        _context.Franchises.Add(franchise);
        await _context.SaveChangesAsync();

        return Ok(franchise);
    }

    // Obtener todas las franquicias
    [HttpGet]
    public async Task<IActionResult> GetFranchises()
    {
        var franchises = await _context.Franchises
            .Include(f => f.Branches)
            .ToListAsync();

        return Ok(franchises);
    }
}