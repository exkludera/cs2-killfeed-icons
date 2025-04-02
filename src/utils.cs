using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Admin;
using CounterStrikeSharp.API.Modules.Utils;

internal class Utils
{
    public static bool HasPermission(CCSPlayerController player, List<string> Permissions, string Team)
    {
        return PermissionCheck(player, Permissions) && AllowedTeam(player, Team);
    }

    public static bool PermissionCheck(CCSPlayerController player, List<string> Permissions)
    {
        if (Permissions.Count <= 0 || Permissions.All(string.IsNullOrEmpty))
            return true;

        foreach (string perm in Permissions)
        {
            if (perm.StartsWith("@") && AdminManager.PlayerHasPermissions(player, perm))
                return true;
            if (perm.StartsWith("#") && AdminManager.PlayerInGroup(player, perm))
                return true;
        }

        return false;
    }

    public static bool AllowedTeam(CCSPlayerController player, string Team)
    {
        Team = Team.ToLower();

        bool isTeamValid =
            (Team == "t" || Team == "terrorist") && player.Team == CsTeam.Terrorist ||
            (Team == "ct" || Team == "counterterrorist") && player.Team == CsTeam.CounterTerrorist ||
            (Team == "" || Team == "both" || Team == "all");

        return isTeamValid;
    }

    private static readonly Dictionary<string, (string eventProp, bool isBool)> EventIconsMappings = new()
    {
        { nameof(Config.ThroughSmoke), (nameof(EventPlayerDeath.Thrusmoke), true) },
        { nameof(Config.NoScope), (nameof(EventPlayerDeath.Noscope), true) },
        { nameof(Config.Headshot), (nameof(EventPlayerDeath.Headshot), true) },
        { nameof(Config.AssistedFlash), (nameof(EventPlayerDeath.Assistedflash), true) },
        { nameof(Config.AttackerBlind), (nameof(EventPlayerDeath.Attackerblind), true) },
        { nameof(Config.AttackerInAir), (nameof(EventPlayerDeath.Attackerinair), true) },
        { nameof(Config.Dominated), (nameof(EventPlayerDeath.Dominated), false) },
        { nameof(Config.Revenge), (nameof(EventPlayerDeath.Revenge), false) },
        { nameof(Config.Penetrated), (nameof(EventPlayerDeath.Penetrated), false) },
        { nameof(Config.SquadWipe), (nameof(EventPlayerDeath.Wipe), false) }
    };

    public static void UpdateEvent(Config config, EventPlayerDeath gameEvent)
    {
        var configProps = typeof(Config).GetProperties();
        var eventProps = typeof(EventPlayerDeath).GetProperties().ToDictionary(p => p.Name);

        foreach (var (configKey, (eventPropName, isBool)) in EventIconsMappings)
        {
            var configProp = configProps.First(p => p.Name == configKey);
            object? value = configProp.GetValue(config);
            int configValue = value is int intValue ? intValue : 0;
            var eventProp = eventProps[eventPropName];

            switch (configValue)
            {
                case 1: // Force enable
                    eventProp.SetValue(gameEvent, isBool ? true : 1);
                    break;
                case 2: // Force disable
                    eventProp.SetValue(gameEvent, isBool ? false : 0);
                    break;
                case 0: // Default (let it decide)
                    break;
            }
        }
    }
}
