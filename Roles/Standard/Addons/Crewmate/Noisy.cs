namespace EHR.Roles;

public class Noisy : AddonBase
{
    public static OptionItem NoisyImpostorAlert;
    public static OptionItem NoisyAlertDuration;
    public override AddonTypes Type => AddonTypes.Helpful;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(15670, CustomRoles.Noisy, canSetNum: true);

        NoisyImpostorAlert = new BooleanOptionItem(15677, "NoisemakerImpostorAlert", true, TabGroup.Addons)
            .SetParent(Options.CustomRoleSpawnChances[CustomRoles.Noisy]);

        NoisyAlertDuration = new FloatOptionItem(15676, "NoisemakerAlertDuration", new(0f, 180f, 1f), 10f, TabGroup.Addons)
            .SetParent(Options.CustomRoleSpawnChances[CustomRoles.Noisy])
            .SetValueFormat(OptionFormat.Seconds);
    }
}