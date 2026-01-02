using System.Collections.Generic;

namespace EHR.Roles;

internal class Observer : RoleBase, IStandardRole
{
    public override bool IsEnable => false;

    public Team Faction => Team.Crewmate;
    public RoleOptionType? Alignment => RoleOptionType.Crewmate_Investigate;
    public IReadOnlyList<CustomRoles> IncompatibleRoles => [];

    public override void SetupCustomOption()
    {
        Options.SetupRoleOptions(7500, TabGroup.CrewmateRoles, CustomRoles.Observer);
    }

    public override void Init() { }

    public override void Add(byte playerId) { }
}