using CounterStrikeSharp.API.Core;

public class Weapon
{
    public string Icon { get; set; } = "";
    public List<string> Permission { get; set; } = [];
    public string Team { get; set; } = "";
}

public class Config : BasePluginConfig
{
    public int Headshot { get; set; } = 0;
    public int ThroughSmoke { get; set; } = 0;
    public int NoScope { get; set; } = 0;
    public int AssistedFlash { get; set; } = 0;
    public int AttackerBlind { get; set; } = 0;
    public int AttackerInAir { get; set; } = 0;
    public int Penetrated { get; set; } = 0;
    public int Dominated { get; set; } = 0;
    public int Revenge { get; set; } = 0;
    public int SquadWipe { get; set; } = 0;
    public Dictionary<string, Weapon> Icons { get; set; } = new();
}