namespace SuperHeroAPI.ApiModel.Plane;

public class GetPlaneModel
{
    public int Id { get; set; }
    public required string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
}