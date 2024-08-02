using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Admin;
using CounterStrikeSharp.API.Modules.Utils;
using static CounterStrikeSharp.API.Core.Listeners;

namespace KillfeedIcons;

public class Weapon
{
    public string Icon { get; set; } = "";
    public string Permission { get; set; } = "";
    public string Team { get; set; } = "";
}

public class Config : BasePluginConfig
{
    public Dictionary<string, Weapon> Icons { get; set; } = new();
}

public partial class Plugin : BasePlugin, IPluginConfig<Config>
{
    public override string ModuleName => "Killfeed Icons";
    public override string ModuleVersion => "1.0.0";
    public override string ModuleAuthor => "exkludera";

    public override void Load(bool hotReload)
    {
        RegisterListener<OnServerPrecacheResources>(OnServerPrecacheResources);
        RegisterEventHandler<EventPlayerDeath>(OnPlayerDeath, HookMode.Pre);
    }

    public override void Unload(bool hotReload)
    {
        RemoveListener<OnServerPrecacheResources>(OnServerPrecacheResources);
        DeregisterEventHandler<EventPlayerDeath>(OnPlayerDeath, HookMode.Pre);
    }

    public void OnServerPrecacheResources(ResourceManifest manifest)
    {
        foreach (var weapon in Config.Icons.Values)
        {
            if (!string.IsNullOrEmpty(weapon.Icon))
                manifest.AddResource(weapon.Icon);
        }
    }

    public Config Config { get; set; } = new Config();
    public void OnConfigParsed(Config config)
    {
        Config = config;
    }

    public bool HasPermission(CCSPlayerController player, Weapon icon)
    {
        string permission = icon.Permission.ToLower();
        string team = icon.Team.ToLower();

        bool isTeamValid = (team == "t" || team == "terrorist") && player.Team == CsTeam.Terrorist ||
                           (team == "ct" || team == "counterterrorist") && player.Team == CsTeam.CounterTerrorist ||
                           (team == "" || team == "both" || team == "all");

        return (string.IsNullOrEmpty(permission) || AdminManager.PlayerHasPermissions(player, permission)) && isTeamValid;
    }

    public HookResult OnPlayerDeath(EventPlayerDeath @event, GameEventInfo info)
    {
        var attacker = @event.Attacker;

        if (attacker == null || !attacker.IsValid || attacker.Connected == PlayerConnectedState.PlayerConnected)
            return HookResult.Continue;

        foreach (var weapon in Config.Icons)
        {
            string weaponName = weapon.Key;
            var icon = weapon.Value;
            if (weapon.Equals(weaponName.ToLower()) && HasPermission(attacker, icon))
            {
                @event.Weapon = icon.Icon;
                break;
            }
        }

        return HookResult.Continue;
    }
}
