namespace SuperHeroAPI.ApiModel.CartoonHero;

public class UpdateCartoonHeroModel
{
    public int Id { get; set; }
    
    public required string Name { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Place { get; set; } = string.Empty;
}