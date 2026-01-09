using System.Collections.Generic;
using AmongUs.GameOptions;
using EHR.Modules;

namespace EHR.Roles;

public class Bestower : StandardRoleBase
{
    public static bool On;

    public override bool IsEnable => On;
    
    private static OptionItem AbilityCooldown;
    private static OptionItem AbilityUseLimit;
    private static OptionItem GivenUses;
    public static OptionItem UsePet;

    public override CustomGamemodes GamemodeId => CustomGamemodes.Standard;
    public override CustomRoles RoleId => CustomRoles.Bestower;
    public override Team Faction => Team.Crewmate;
    public override RoleOptionType? Alignment => RoleOptionType.Crewmate_Support;

    public override void SetupCustomOption()
    {
        StartSetup(657200)
            .AutoSetupOption(ref AbilityCooldown, 30f, new FloatValueRule(0.5f, 120f, 0.5f), OptionFormat.Seconds)
            .AutoSetupOption(ref AbilityUseLimit, 3, new IntegerValueRule(1, 20, 1), OptionFormat.Times)
            .AutoSetupOption(ref GivenUses, 1f, new FloatValueRule(0.05f, 20f, 0.05f), OptionFormat.Times)
            .CreatePetUseSetting(ref UsePet);
    }

    public override void Init()
    {
        On = false;
    }

    public override void Add(byte playerId)
    {
        On = true;
        playerId.SetAbilityUseLimit(AbilityUseLimit.GetInt());
    }

    public override void SetKillCooldown(byte id)
    {
        Main.AllPlayerKillCooldown[id] = AbilityCooldown.GetFloat();
    }

    public override bool CanUseKillButton(PlayerControl player)
    {
        return player.GetAbilityUseLimit() > 0;
    }

    public override bool CanUseImpostorVentButton(PlayerControl pc)
    {
        return false;
    }

    public override void ApplyGameOptions(IGameOptions opt, byte playerId)
    {
        opt.SetVision(false);
    }

    public override bool OnCheckMurder(PlayerControl killer, PlayerControl target)
    {
        float give = GivenUses.GetFloat();
        RPC.PlaySoundRPC(target.PlayerId, Sounds.TaskUpdateSound);
        target.RpcIncreaseAbilityUseLimitBy(give);
        killer.RpcRemoveAbilityUse();
        killer.SetKillCooldown();
        return false;
    }
}
