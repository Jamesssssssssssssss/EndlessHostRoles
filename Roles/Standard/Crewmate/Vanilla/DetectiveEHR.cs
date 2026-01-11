using static EHR.Options;

namespace EHR.Roles;

internal class DetectiveEHR : RoleBase
{
    public static OptionItem DetectiveSuspectLimit;

    public override bool IsEnable => false;

    public override CustomRoles RoleId => CustomRoles.DetectiveEHR;
    public override CustomGamemodes GamemodeId => CustomGamemodes.Standard;

    public override void Add(byte playerId) { }
    public override void Init() { }

    public override void SetupCustomOption()
    {
        SetupRoleOptions(5080, TabGroup.CrewmateRoles, CustomRoles.DetectiveEHR);

        DetectiveSuspectLimit =
            new FloatOptionItem(5082, "DetectiveSuspectLimit", new(1f, 30f, 1f), 4f, TabGroup.CrewmateRoles)
                .SetParent(CustomRoleSpawnChances[CustomRoles.DetectiveEHR])
                .SetValueFormat(OptionFormat.Players);
    }
}
