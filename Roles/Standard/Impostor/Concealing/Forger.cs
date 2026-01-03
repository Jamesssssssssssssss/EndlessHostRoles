using System.Collections.Generic;

namespace EHR.Roles;

public class Forger : StandardRoleBase
{
    public static bool On;

    public static Dictionary<byte, CustomRoles> Forges = [];

    private static OptionItem AbilityUseLimit;
    private static OptionItem AbilityUseGainWithEachKill;

    public override bool IsEnable => On;

    public override Team Faction => Team.Impostor;
    public override RoleOptionType? Alignment => RoleOptionType.Impostor_Concealing;

    public override void SetupCustomOption()
    {
        StartSetup(651700)
            .AutoSetupOption(ref AbilityUseLimit, 1f, new FloatValueRule(0, 20, 0.05f), OptionFormat.Times)
            .AutoSetupOption(ref AbilityUseGainWithEachKill, 0.4f, new FloatValueRule(0f, 5f, 0.1f), OptionFormat.Times);
    }

    public override void Init()
    {
        On = false;
        Forges = [];
    }

    public override void Add(byte playerId)
    {
        On = true;
        playerId.SetAbilityUseLimit(AbilityUseLimit.GetFloat());
    }
}