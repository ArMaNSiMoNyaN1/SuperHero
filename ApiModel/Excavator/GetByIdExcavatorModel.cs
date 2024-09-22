namespace SuperHeroAPI.ApiModel.Excavator;

public class GetByIdExcavatorModel
{
    
    public int Id { get; set; }
    
    public required string Brand { get; set; }
    
    public string Model { get; set; }

    public string Price { get; set; } 

}