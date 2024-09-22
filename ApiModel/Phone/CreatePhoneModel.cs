namespace SuperHeroAPI.ApiModel.Phone;

public class CreatePhoneModel
{
    public  required string Brand { get; set; }
    
    public string Model { get; set; }

    public string Country { get; set; }
}