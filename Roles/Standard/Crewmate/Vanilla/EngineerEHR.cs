using static EHR.Options;

namespace EHR.Roles;

internal class EngineerEHR : RoleBase
{
    public static OptionItem EngineerCD;
    public static OptionItem EngineerDur;

    public override bool IsEnable => false;

    public override CustomRoles RoleId => CustomRoles.EngineerEHR;
    public override CustomGamemodes GamemodeId => CustomGamemodes.Standard;

    public override void Add(byte playerId) { }
    public override void Init() { }

    public override void SetupCustomOption()
    {
        SetupRoleOptions(5000, TabGroup.CrewmateRoles, CustomRoles.EngineerEHR);

        EngineerCD =
            new FloatOptionItem(5002, "VentCooldown", new(1f, 250f, 1f), 30f, TabGroup.CrewmateRoles)
                .SetParent(CustomRoleSpawnChances[CustomRoles.EngineerEHR])
                .SetValueFormat(OptionFormat.Seconds);

        EngineerDur =
            new FloatOptionItem(5003, "MaxInVentTime", new(1f, 250f, 1f), 15f, TabGroup.CrewmateRoles)
                .SetParent(CustomRoleSpawnChances[CustomRoles.EngineerEHR])
                .SetValueFormat(OptionFormat.Seconds);
    }
}
