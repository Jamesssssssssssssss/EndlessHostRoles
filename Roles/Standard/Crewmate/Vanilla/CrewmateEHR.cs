using static EHR.Options;

namespace EHR.Roles;

internal class CrewmateEHR : RoleBase
{
    public static OptionItem VanillaCrewmateCannotBeGuessed;

    public override bool IsEnable => false;

    public override CustomRoles RoleId => CustomRoles.CrewmateEHR;
    public override CustomGamemodes GamemodeId => CustomGamemodes.Standard;

    public override void Add(byte playerId)
    { }

    public override void Init()
    { }

    public override void SetupCustomOption()
    {
        SetupRoleOptions(5020, TabGroup.CrewmateRoles, CustomRoles.CrewmateEHR);

        VanillaCrewmateCannotBeGuessed =
            new BooleanOptionItem(5022, "VanillaCrewmateCannotBeGuessed", false, TabGroup.CrewmateRoles)
                .SetParent(CustomRoleSpawnChances[CustomRoles.CrewmateEHR]);
    }
}
