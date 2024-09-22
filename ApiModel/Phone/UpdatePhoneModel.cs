namespace SuperHeroAPI.ApiModel.Phone;

public class UpdatePhoneModel
{
    public int Id { get; set; }
    
    public string Brand { get; set; }
    
    public string Model { get; set; }

    public string Country { get; set; }
}