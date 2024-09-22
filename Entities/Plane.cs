namespace SuperHeroAPI.Entities;

public class Plane
{
    public int Id { get; set; }
    public required string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Country { get; set; }
}