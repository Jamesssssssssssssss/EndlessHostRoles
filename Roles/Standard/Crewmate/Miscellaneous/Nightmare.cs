using System.Collections.Generic;

namespace EHR.Roles;

public class Nightmare : StandardRoleBase
{
    public static bool On;
    public override bool IsEnable => On;

    public override void Add(byte playerId)
    {
        On = true;
    }

    public override void Init()
    {
        On = false;
    }

    public override CustomGamemodes GamemodeId => CustomGamemodes.Standard;
    public override CustomRoles RoleId => CustomRoles.Nightmare;
    public override Team Faction => Team.Crewmate;
    public override RoleOptionType? Alignment => RoleOptionType.Crewmate_Miscellaneous;

    public override void SetupCustomOption()
    {
        Options.SetupRoleOptions(642630, TabGroup.CrewmateRoles, CustomRoles.Nightmare);
    }

    public override bool OnCheckMurderAsTarget(PlayerControl killer, PlayerControl target)
    {
        return !Utils.IsActive(SystemTypes.Electrical);
    }
}