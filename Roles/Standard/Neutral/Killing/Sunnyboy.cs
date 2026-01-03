using System.Collections.Generic;
using AmongUs.GameOptions;

namespace EHR.Roles;

internal class Sunnyboy : StandardRoleBase
{
    public static bool On;
    public override bool IsEnable => On;

    public override Team Faction => Team.Neutral;
    public override RoleOptionType? Alignment => RoleOptionType.Neutral_Killing;

    public override void SetupCustomOption() { }

    public override void Add(byte playerId)
    {
        On = true;
    }

    public override void Init()
    {
        On = false;
    }

    public override void ApplyGameOptions(IGameOptions opt, byte playerId)
    {
        AURoleOptions.ScientistCooldown = 0f;
        AURoleOptions.ScientistBatteryCharge = 60f;
    }
}