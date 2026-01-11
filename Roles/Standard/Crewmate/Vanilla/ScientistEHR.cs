using static EHR.Options;

namespace EHR.Roles;

internal class ScientistEHR : RoleBase
{
    public static OptionItem ScientistCD;
    public static OptionItem ScientistDur;

    public override bool IsEnable => false;

    public override CustomRoles RoleId => CustomRoles.ScientistEHR;
    public override CustomGamemodes GamemodeId => CustomGamemodes.Standard;

    public override void Add(byte playerId) { }
    public override void Init() { }

    public override void SetupCustomOption()
    {
        SetupRoleOptions(5100, TabGroup.CrewmateRoles, CustomRoles.ScientistEHR);

        ScientistCD =
            new FloatOptionItem(5102, "VitalsCooldown", new(1f, 250f, 1f), 3f, TabGroup.CrewmateRoles)
                .SetParent(CustomRoleSpawnChances[CustomRoles.ScientistEHR])
                .SetValueFormat(OptionFormat.Seconds);

        ScientistDur =
            new FloatOptionItem(5103, "VitalsDuration", new(1f, 250f, 1f), 15f, TabGroup.CrewmateRoles)
                .SetParent(CustomRoleSpawnChances[CustomRoles.ScientistEHR])
                .SetValueFormat(OptionFormat.Seconds);
    }
}
