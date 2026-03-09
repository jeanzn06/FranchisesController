namespace Franchise.Api.Models;

public class Franchise
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public List<Branch> Branches { get; set; } = new();
}