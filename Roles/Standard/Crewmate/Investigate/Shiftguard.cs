using System.Collections.Generic;

namespace EHR.Roles;

internal class Shiftguard : RoleBase, IStandardRole
{
    public override bool IsEnable => false;

    public Team Faction => Team.Crewmate;
    public RoleOptionType? Alignment => RoleOptionType.Crewmate_Investigate;
    public IReadOnlyList<CustomRoles> IncompatibleRoles => [];

    public override void SetupCustomOption()
    {
        Options.SetupRoleOptions(5594, TabGroup.CrewmateRoles, CustomRoles.Shiftguard);
    }

    public override void Init() { }

    public override void Add(byte playerId) { }
}