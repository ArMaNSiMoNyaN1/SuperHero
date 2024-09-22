namespace SuperHeroAPI.ApiModel.Actor;

public class GetActorModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Place { get; set; } = string.Empty;
}