using System.Collections.Generic;

namespace EHR.Roles;

internal class Guardian : RoleBase, IStandardRole
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

    public override bool OnCheckMurderAsTarget(PlayerControl killer, PlayerControl target)
    {
        return !target.AllTasksCompleted();
    }

    public Team Faction => Team.Crewmate;
    public RoleOptionType? Alignment => RoleOptionType.Crewmate_Power;
    public IReadOnlyList<CustomRoles> IncompatibleRoles => [];

    public override void SetupCustomOption()
    {
        Options.SetupRoleOptions(9200, TabGroup.CrewmateRoles, CustomRoles.Guardian);
        Options.OverrideTasksData.Create(9210, TabGroup.CrewmateRoles, CustomRoles.Guardian);
    }
}