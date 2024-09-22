namespace SuperHeroAPI.ApiModel.Car;

public class CreateCarModel
{
    public required string Brand { get; set; }
    public string Model { get; set; }
    public string Country { get; set; }
}