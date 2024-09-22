namespace SuperHeroAPI.ApiModel.CartoonHero;
public class GetByIdCartoonHeroModel
{
    public required string Name { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Place { get; set; } = string.Empty;
}