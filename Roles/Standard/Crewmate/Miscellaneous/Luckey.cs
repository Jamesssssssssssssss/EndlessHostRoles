using System.Collections.Generic;

namespace EHR.Roles;

internal class Luckey : StandardRoleBase
{
    public static bool On;
    public override bool IsEnable => On;

    public override CustomGamemodes GamemodeId => CustomGamemodes.Standard;
    public override CustomRoles RoleId => CustomRoles.Luckey;
    public override Team Faction => Team.Crewmate;
    public override RoleOptionType? Alignment => RoleOptionType.Crewmate_Miscellaneous;

    public override void SetupCustomOption()
    {
        Options.SetupRoleOptions(5800, TabGroup.CrewmateRoles, CustomRoles.Luckey);

        Options.LuckeyProbability = new IntegerOptionItem(5900, "LuckeyProbability", new(0, 100, 5), 50, TabGroup.CrewmateRoles)
            .SetParent(Options.CustomRoleSpawnChances[CustomRoles.Luckey])
            .SetValueFormat(OptionFormat.Percent);
    }

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
        var rd = IRandom.Instance;

        if (rd.Next(0, 100) < Options.LuckeyProbability.GetInt())
        {
            killer.SetKillCooldown(15f);
            return false;
        }

        return true;
    }
}