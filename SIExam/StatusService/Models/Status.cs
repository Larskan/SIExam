namespace StatusService.Models;

public class Status
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int Level { get; set; }
    public required int Experience { get; set; }
    public required string Goal { get; set; }
    public int Vitality { get; set; }
    public int Endurance { get; set; }
    public int Strength { get; set; }
    public int Intelligence { get; set; }
    public int Mentality { get; set; }
    public int Dexterity { get; set; }
}