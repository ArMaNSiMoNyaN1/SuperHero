namespace SuperHeroAPI.ApiModel.Excavator;

public class CreateExcavatorModel
{
    public required string Brand { get; set; }
    
    public string Model { get; set; }

    public string Price { get; set; } 
}