using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Franchise.Api.Data;
using Franchise.Api.Models;

namespace Franchise.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(Product product)
    {
        var branch = await _context.Branches.FindAsync(product.BranchId);

        if (branch == null)
        {
            return NotFound("Branch not found");
        }

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return Ok(product);
    }
    [HttpPut("{id}/stock")]
public async Task<IActionResult> UpdateStock(int id, int stock)
{
    var product = await _context.Products.FindAsync(id);

    if (product == null)
    {
        return NotFound("Product not found");
    }

    product.Stock = stock;

    await _context.SaveChangesAsync();

    return Ok(product);
}
}
