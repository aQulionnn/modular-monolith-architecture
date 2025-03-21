namespace Modules.Pianos.Entities;

public class Piano
{
    public Guid Id { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }
    public int KeyCount { get; set; }
    public bool IsAcoustic { get; set; }
    public bool HasPedals { get; set; }
    public string BodyMaterial { get; set; }
}