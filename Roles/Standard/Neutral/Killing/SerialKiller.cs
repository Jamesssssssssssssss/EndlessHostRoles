using System.Collections.Generic;

using AmongUs.GameOptions;

namespace EHR.Roles;

public class SerialKiller : StandardRoleBase
{
    public static bool On;

    private static OptionItem KillCooldown;
    private static OptionItem CanVent;
    private static OptionItem ImpostorVision;

    public override bool IsEnable => On;

    public override CustomGamemodes GamemodeId => CustomGamemodes.Standard;
    public override CustomRoles RoleId => CustomRoles.SerialKiller;
    public override Team Faction => Team.Neutral;
    public override RoleOptionType? Alignment => RoleOptionType.Neutral_Killing;

    public override void SetupCustomOption()
    {
        StartSetup(12800)
            .AutoSetupOption(ref KillCooldown, 22.5f, new FloatValueRule(0f, 180f, 0.5f), OptionFormat.Seconds)
            .AutoSetupOption(ref CanVent, true)
            .AutoSetupOption(ref ImpostorVision, true);
    }

    public override void Init()
    {
        On = false;
    }

    public override void Add(byte playerId)
    {
        On = true;
    }

    public override void SetKillCooldown(byte id)
    {
        Main.AllPlayerKillCooldown[id] = KillCooldown.GetFloat();
    }

    public override void ApplyGameOptions(IGameOptions opt, byte id)
    {
        opt.SetVision(ImpostorVision.GetBool());
    }

    public override bool CanUseImpostorVentButton(PlayerControl pc)
    {
        return CanVent.GetBool();
    }
}