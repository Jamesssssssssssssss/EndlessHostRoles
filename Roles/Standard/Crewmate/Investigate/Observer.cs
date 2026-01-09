using System.Collections.Generic;

namespace EHR.Roles;

internal class Observer : StandardRoleBase
{
    public override bool IsEnable => false;

    public override CustomGamemodes GamemodeId => CustomGamemodes.Standard;
    public override CustomRoles RoleId => CustomRoles.Observer;
    public override Team Faction => Team.Crewmate;
    public override RoleOptionType? Alignment => RoleOptionType.Crewmate_Investigate;

    public override void SetupCustomOption()
    {
        Options.SetupRoleOptions(7500, TabGroup.CrewmateRoles, CustomRoles.Observer);
    }

    public override void Init() { }

    public override void Add(byte playerId) { }
}