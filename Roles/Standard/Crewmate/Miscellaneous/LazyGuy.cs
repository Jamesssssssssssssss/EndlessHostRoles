using System.Collections.Generic;

namespace EHR.Roles;

internal class LazyGuy : StandardRoleBase
{
    public override bool IsEnable => false;

    public override CustomGamemodes GamemodeId => CustomGamemodes.Standard;
    public override CustomRoles RoleId => CustomRoles.LazyGuy;
    public override Team Faction => Team.Crewmate;
    public override RoleOptionType? Alignment => RoleOptionType.Crewmate_Miscellaneous;

    public override void SetupCustomOption()
    {
        Options.SetupRoleOptions(5700, TabGroup.CrewmateRoles, CustomRoles.LazyGuy);
    }

    public override void Init() { }

    public override void Add(byte playerId) { }
}