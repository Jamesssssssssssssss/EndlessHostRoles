using System.Collections.Generic;

namespace EHR.Roles;

internal class Detour : StandardRoleBase
{
    public static int TotalRedirections;
    public override bool IsEnable => false;

    public override Team Faction => Team.Crewmate;
    public override RoleOptionType? Alignment => RoleOptionType.Crewmate_Power;

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