namespace SuperHeroAPI.ApiModel.Car;

public class GetByIdCarModel
{
    public required string Brand { get; set; }
    public string Model { get; set; }
    public string Country { get; set; }
}