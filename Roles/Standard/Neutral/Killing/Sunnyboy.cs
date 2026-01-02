using System.Collections.Generic;
using AmongUs.GameOptions;

namespace EHR.Roles;

internal class Sunnyboy : RoleBase, IStandardRole
{
    public static bool On;
    public override bool IsEnable => On;

    public Team Faction => Team.Neutral;
    public RoleOptionType? Alignment => RoleOptionType.Neutral_Killing;
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

    public override void ApplyGameOptions(IGameOptions opt, byte playerId)
    {
        AURoleOptions.ScientistCooldown = 0f;
        AURoleOptions.ScientistBatteryCharge = 60f;
    }
}