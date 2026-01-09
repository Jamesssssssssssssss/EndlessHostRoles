namespace EHR.Roles;

public class Onbound : AddonBase
{
    public static OptionItem GuesserSuicides;
    public override AddonTypes Type => AddonTypes.Mixed;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(14500, CustomRoles.Onbound, canSetNum: true, teamSpawnOptions: true);

        GuesserSuicides = new BooleanOptionItem(14508, "GuesserSuicides", false, TabGroup.Addons)
            .SetParent(Options.CustomRoleSpawnChances[CustomRoles.Onbound])
            .SetGameMode(CustomGamemodes.Standard);
    }
}