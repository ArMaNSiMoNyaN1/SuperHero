namespace SuperHeroAPI.ApiModel.Car;

public class UpdateCarModel
{
    public int Id { get; set; }
    public required string Brand { get; set; }
    public string Model { get; set; }
    public string Country { get; set; }
}