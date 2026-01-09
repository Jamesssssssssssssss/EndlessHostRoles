using System.Collections.Generic;

namespace EHR.Roles;

public class Bane : StandardRoleBase
{
    public static bool On;
    public override bool IsEnable => On;

    public override void Init()
    {
        On = false;
    }

    public override void Add(byte playerId)
    {
        On = true;
    }

    public override CustomGamemodes GamemodeId => CustomGamemodes.Standard;
    public override CustomRoles RoleId => CustomRoles.Bane;
    public override Team Faction => Team.Crewmate;
    public override RoleOptionType? Alignment => RoleOptionType.Crewmate_Support;

    public override void SetupCustomOption()
    {
        Options.SetupRoleOptions(642600, TabGroup.CrewmateRoles, CustomRoles.Bane);
    }

    public static void OnKilled(PlayerControl killer)
    {
        if (killer == null || killer.Is(CustomRoles.Bloodlust)) return;

        CustomRoles erasedRole = killer.IsImpostor() ? CustomRoles.ImpostorEHR : killer.IsCrewmate() ? CustomRoles.CrewmateEHR : killer.Is(Team.Coven) ? CustomRoles.CovenMember : CustomRoles.Amnesiac;
        killer.RpcSetCustomRole(erasedRole);
        killer.RpcChangeRoleBasis(erasedRole);
    }
}