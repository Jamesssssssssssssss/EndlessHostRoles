using System.Collections.Generic;
using System.Linq;

namespace EHR.Roles;

internal class Autocrat : StandardRoleBase
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

    public override Team Faction => Team.Crewmate;
    public override RoleOptionType? Alignment => RoleOptionType.Crewmate_Support;

    public override void SetupCustomOption()
    {
        Options.SetupRoleOptions(642620, TabGroup.CrewmateRoles, CustomRoles.Autocrat);
    }

    public override void OnTaskComplete(PlayerControl pc, int completedTaskCount, int totalTaskCount)
    {
        if (!pc.IsAlive()) return;

        Main.AllAlivePlayerControls.OrderBy(x => Vector2.Distance(x.Pos(), pc.Pos())).FirstOrDefault(x => x.PlayerId != pc.PlayerId)?.TP(pc);
    }
}