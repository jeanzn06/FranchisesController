namespace Franchise.Api.Models;

public class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int Stock { get; set; }

    public int BranchId { get; set; }

    public Branch? Branch { get; set; }
}
