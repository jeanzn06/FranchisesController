namespace Franchise.Api.Models;

public class Branch
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int FranchiseId { get; set; }

    public Franchise? Franchise { get; set; }

    public List<Product> Products { get; set; } = new();
}