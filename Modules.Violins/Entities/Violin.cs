namespace Modules.Violins.Entities;

public class Violin
{
    public Guid Id { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }
    public decimal Size { get; set; }
    public string StringMaterial { get; set; }
    public string BodyWood { get; set; }
    public string BowMaterial { get; set; }
}