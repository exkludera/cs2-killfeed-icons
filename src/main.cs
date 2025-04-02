using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;

public partial class Plugin : BasePlugin, IPluginConfig<Config>
{
    public override string ModuleName => "Killfeed Icons";
    public override string ModuleVersion => "1.0.1";
    public override string ModuleAuthor => "exkludera";

    public override void Load(bool hotReload)
    {
        RegisterListener<Listeners.OnServerPrecacheResources>(OnServerPrecacheResources);
        RegisterEventHandler<EventPlayerDeath>(OnPlayerDeath, HookMode.Pre);
    }

    public override void Unload(bool hotReload)
    {
        RemoveListener<Listeners.OnServerPrecacheResources>(OnServerPrecacheResources);
        DeregisterEventHandler<EventPlayerDeath>(OnPlayerDeath, HookMode.Pre);
    }

    public Config Config { get; set; } = new Config();
    public void OnConfigParsed(Config config)
    {
        Config = config;
    }

    public void OnServerPrecacheResources(ResourceManifest manifest)
    {
        foreach (var weapon in Config.Icons.Values)
        {
            if (!string.IsNullOrEmpty(weapon.Icon))
                manifest.AddResource(weapon.Icon);
        }
    }

    public HookResult OnPlayerDeath(EventPlayerDeath @event, GameEventInfo info)
    {
        var attacker = @event.Attacker;

        if (attacker == null || attacker.Connected != PlayerConnectedState.PlayerConnected)
            return HookResult.Continue;

        Utils.UpdateEvent(Config, @event);

        var match = Config.Icons.FirstOrDefault(x =>
            Utils.HasPermission(attacker, x.Value.Permission, x.Value.Team) &&
            (x.Key.ToLower() == @event.Weapon ||
            (x.Key == "knife" && (@event.Weapon.Contains("knife") || @event.Weapon == "bayonet")) ||
            x.Key == "*"));

        if (match.Value != null)
            @event.Weapon = match.Value.Icon;

        return HookResult.Continue;
    }
}