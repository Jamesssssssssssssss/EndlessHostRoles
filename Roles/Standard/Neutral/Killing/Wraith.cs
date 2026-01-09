using System.Collections.Generic;

namespace EHR.Roles;

public class Wraith : StandardRoleBase
{
    public static OptionItem WraithCooldown;
    public static OptionItem WraithDuration;
    public static OptionItem WraithVentNormallyOnCooldown;
    public static OptionItem WraithCanVent;
    public static OptionItem ImpostorVision;
    public static OptionItem KillCooldown;

    public override bool IsEnable => false;

    public override CustomGamemodes GamemodeId => CustomGamemodes.Standard;
    public override CustomRoles RoleId => CustomRoles.Wraith;
    public override Team Faction => Team.Neutral;
    public override RoleOptionType? Alignment => RoleOptionType.Neutral_Killing;

    public override void SetupCustomOption()
    {
        StartSetup(13300)
            .AutoSetupOption(ref WraithCooldown, 20f, new FloatValueRule(0f, 60f, 0.5f), OptionFormat.Seconds)
            .AutoSetupOption(ref WraithDuration, 10f, new FloatValueRule(0.5f, 30f, 0.5f), OptionFormat.Seconds)
            .AutoSetupOption(ref WraithVentNormallyOnCooldown, true)
            .AutoSetupOption(ref WraithCanVent, true, overrideName: "CanVent")
            .AutoSetupOption(ref ImpostorVision, true)
            .AutoSetupOption(ref KillCooldown, 22.5f, new FloatValueRule(0.5f, 120f, 0.5f), OptionFormat.Seconds);
    }

    public override void Init() { }

    public override void Add(byte playerId) { }
}
