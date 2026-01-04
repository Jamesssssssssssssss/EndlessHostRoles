namespace EHR.Roles;

public class Listener : AddonBase
{
    public override AddonTypes Type => AddonTypes.Helpful;

    public static OptionItem WhisperHearChance;
    public static OptionItem FullMessageHearChance;

    public static int LocalPlayerHeardMessagesThisMeeting;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(653800, CustomRoles.Listener, canSetNum: true, teamSpawnOptions: true);
        
        WhisperHearChance = new IntegerOptionItem(653810, "Listener.WhisperHearChance", new(5, 100, 5), 50, TabGroup.Addons)
            .SetValueFormat(OptionFormat.Percent)
            .SetParent(Options.CustomRoleSpawnChances[CustomRoles.Listener]);
        
        FullMessageHearChance = new IntegerOptionItem(653820, "Listener.FullMessageHearChance", new(0, 100, 5), 20, TabGroup.Addons)
            .SetValueFormat(OptionFormat.Percent)
            .SetParent(Options.CustomRoleSpawnChances[CustomRoles.Listener]);
    }
}