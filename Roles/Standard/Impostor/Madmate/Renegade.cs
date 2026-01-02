using System.Collections.Generic;
using AmongUs.GameOptions;

namespace EHR.Roles;

internal class Renegade : RoleBase, IStandardRole
{
    public static bool On;
    public override bool IsEnable => On;

    public Team Faction => Team.Impostor;
    public RoleOptionType? Alignment => RoleOptionType.Impostor_Madmate;
    public IReadOnlyList<CustomRoles> IncompatibleRoles => [];

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