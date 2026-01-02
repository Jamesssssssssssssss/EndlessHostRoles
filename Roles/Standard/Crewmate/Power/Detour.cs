using System.Collections.Generic;

namespace EHR.Roles;

internal class Detour : RoleBase, IStandardRole
{
    public static int TotalRedirections;
    public override bool IsEnable => false;

    public Team Faction => Team.Crewmate;
    public RoleOptionType? Alignment => RoleOptionType.Crewmate_Power;
    public IReadOnlyList<CustomRoles> IncompatibleRoles => [];

    public override void SetupCustomOption()
    {
        Options.SetupRoleOptions(5590, TabGroup.CrewmateRoles, CustomRoles.Detour);
    }

    public override void Init()
    {
        TotalRedirections = 0;
    }

    public override void Add(byte playerId) { }
}