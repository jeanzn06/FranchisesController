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
    [HttpGet("{id}/top-products")]
public async Task<IActionResult> GetTopProductsByFranchise(int id)
{
    var franchise = await _context.Franchises
        .Include(f => f.Branches)
        .ThenInclude(b => b.Products)
        .FirstOrDefaultAsync(f => f.Id == id);

    if (franchise == null)
    {
        return NotFound("Franchise not found");
    }

   var result = franchise.Branches.Select(branch => new
{
    Branch = branch.Name,
    TopProduct = branch.Products?
        .OrderByDescending(p => p.Stock)
        .Select(p => new
        {
            p.Name,
            p.Stock
        })
        .FirstOrDefault()
});
    return Ok(result);
}
}