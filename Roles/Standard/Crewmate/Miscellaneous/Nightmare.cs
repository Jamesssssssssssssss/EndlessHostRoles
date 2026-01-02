using System.Collections.Generic;

namespace EHR.Roles;

public class Nightmare : RoleBase, IStandardRole
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

    public Team Faction => Team.Crewmate;
    public RoleOptionType? Alignment => RoleOptionType.Crewmate_Miscellaneous;
    public IReadOnlyList<CustomRoles> IncompatibleRoles => [];

    public override void SetupCustomOption()
    {
        Options.SetupRoleOptions(642630, TabGroup.CrewmateRoles, CustomRoles.Nightmare);
    }

    public override bool OnCheckMurderAsTarget(PlayerControl killer, PlayerControl target)
    {
        return !Utils.IsActive(SystemTypes.Electrical);
    }
}