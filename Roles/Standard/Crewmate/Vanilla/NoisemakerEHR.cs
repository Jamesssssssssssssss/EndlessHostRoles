using static EHR.Options;

namespace EHR.Roles;

internal class NoisemakerEHR : RoleBase
{
    public static OptionItem NoiseMakerImpostorAlert;
    public static OptionItem NoisemakerAlertDuration;

    public override bool IsEnable => false;

    public override CustomRoles RoleId => CustomRoles.NoisemakerEHR;
    public override CustomGamemodes GamemodeId => CustomGamemodes.Standard;

    public override void Add(byte playerId) { }
    public override void Init() { }

    public override void SetupCustomOption()
    {
        SetupRoleOptions(5040, TabGroup.CrewmateRoles, CustomRoles.NoisemakerEHR);

        NoiseMakerImpostorAlert =
            new BooleanOptionItem(5042, "NoisemakerImpostorAlert", false, TabGroup.CrewmateRoles)
                .SetParent(CustomRoleSpawnChances[CustomRoles.NoisemakerEHR]);

        NoisemakerAlertDuration =
            new FloatOptionItem(5043, "NoisemakerAlertDuration", new(1f, 250f, 1f), 5f, TabGroup.CrewmateRoles)
                .SetParent(CustomRoleSpawnChances[CustomRoles.NoisemakerEHR])
                .SetValueFormat(OptionFormat.Seconds);
    }
}
