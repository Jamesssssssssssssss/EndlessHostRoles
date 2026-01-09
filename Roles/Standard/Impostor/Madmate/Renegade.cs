using System.Collections.Generic;
using AmongUs.GameOptions;

namespace EHR.Roles;

internal class Renegade : StandardRoleBase
{
    public static bool On;
    public override bool IsEnable => On;

    public override CustomGamemodes GamemodeId => CustomGamemodes.Standard;
    public override CustomRoles RoleId => CustomRoles.Renegade;
    public override Team Faction => Team.Impostor;
    public override RoleOptionType? Alignment => RoleOptionType.Impostor_Madmate;

    public override void SetupCustomOption() { }

    public override void Add(byte playerId)
    {
        On = true;
    }

    public override void Init()
    {
        On = false;
    }

    public override void SetKillCooldown(byte id)
    {
        Main.AllPlayerKillCooldown[id] = Options.RenegadeKillCD.GetFloat();
    }

    public override void ApplyGameOptions(IGameOptions opt, byte playerId)
    {
        opt.SetVision(true);
    }

    public override bool CanUseKillButton(PlayerControl pc)
    {
        return pc.IsAlive();
    }
}