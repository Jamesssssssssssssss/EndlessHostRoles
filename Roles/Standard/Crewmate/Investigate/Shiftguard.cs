using System.Collections.Generic;

namespace EHR.Roles;

internal class Shiftguard : StandardRoleBase
{
    public override bool IsEnable => false;

    public override CustomGamemodes GamemodeId => CustomGamemodes.Standard;
    public override CustomRoles RoleId => CustomRoles.Shiftguard;
    public override Team Faction => Team.Crewmate;
    public override RoleOptionType? Alignment => RoleOptionType.Crewmate_Investigate;

    public override void SetupCustomOption()
    {
        Options.SetupRoleOptions(5594, TabGroup.CrewmateRoles, CustomRoles.Shiftguard);
    }

    public override void Init() { }

    public override void Add(byte playerId) { }
}