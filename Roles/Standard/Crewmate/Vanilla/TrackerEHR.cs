using static EHR.Options;

namespace EHR.Roles;

internal class TrackerEHR : RoleBase
{
    public static OptionItem TrackerCooldown;
    public static OptionItem TrackerDuration;
    public static OptionItem TrackerDelay;

    public override bool IsEnable => false;

    public override CustomRoles RoleId => CustomRoles.TrackerEHR;
    public override CustomGamemodes GamemodeId => CustomGamemodes.Standard;

    public override void Add(byte playerId) { }
    public override void Init() { }

    public override void SetupCustomOption()
    {
        SetupRoleOptions(5060, TabGroup.CrewmateRoles, CustomRoles.TrackerEHR);

        TrackerCooldown =
            new FloatOptionItem(5062, "TrackerCooldown", new(1f, 250f, 1f), 25f, TabGroup.CrewmateRoles)
                .SetParent(CustomRoleSpawnChances[CustomRoles.TrackerEHR])
                .SetValueFormat(OptionFormat.Seconds);

        TrackerDuration =
            new FloatOptionItem(5063, "TrackerDuration", new(1f, 250f, 1f), 20f, TabGroup.CrewmateRoles)
                .SetParent(CustomRoleSpawnChances[CustomRoles.TrackerEHR])
                .SetValueFormat(OptionFormat.Seconds);

        TrackerDelay =
            new FloatOptionItem(5064, "TrackerDelay", new(1f, 250f, 1f), 5f, TabGroup.CrewmateRoles)
                .SetParent(CustomRoleSpawnChances[CustomRoles.TrackerEHR])
                .SetValueFormat(OptionFormat.Seconds);
    }
}
