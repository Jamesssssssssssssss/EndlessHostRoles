using System.Collections.Generic;

namespace EHR.Roles;

internal class LazyGuy : RoleBase, IStandardRole
{
    public override bool IsEnable => false;

    public Team Faction => Team.Crewmate;
    public RoleOptionType? Alignment => RoleOptionType.Crewmate_Miscellaneous;
    public IReadOnlyList<CustomRoles> IncompatibleRoles => [];

    public override void SetupCustomOption()
    {
        Options.SetupRoleOptions(5700, TabGroup.CrewmateRoles, CustomRoles.LazyGuy);
    }

    public override void Init() { }

    public override void Add(byte playerId) { }
}