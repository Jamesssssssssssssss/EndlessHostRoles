using System.Collections.Generic;
using AmongUs.GameOptions;
using EHR.Modules;

namespace EHR.Roles;

internal class Freezer : RoleBase, IStandardRole
{
    private const int Id = 643530;
    public static bool On;

    private static OptionItem FreezeCooldown;
    private static OptionItem FreezeDuration;
    public override bool IsEnable => On;

    public Team Faction => Team.Impostor;
    public RoleOptionType? Alignment => RoleOptionType.Impostor_Support;
    public IReadOnlyList<CustomRoles> IncompatibleRoles => [];

    public override void SetupCustomOption()
    {
        Options.SetupRoleOptions(Id, TabGroup.ImpostorRoles, CustomRoles.Freezer);

        FreezeCooldown = new FloatOptionItem(Id + 2, "FreezeCooldown", new(0f, 180f, 0.5f), 30f, TabGroup.ImpostorRoles)
            .SetParent(Options.CustomRoleSpawnChances[CustomRoles.Freezer])
            .SetValueFormat(OptionFormat.Seconds);

        FreezeDuration = new FloatOptionItem(Id + 3, "FreezeDuration", new(0f, 180f, 0.5f), 10f, TabGroup.ImpostorRoles)
            .SetParent(Options.CustomRoleSpawnChances[CustomRoles.Freezer])
            .SetValueFormat(OptionFormat.Seconds);
    }

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
        AURoleOptions.ShapeshifterCooldown = FreezeCooldown.GetFloat();
        AURoleOptions.ShapeshifterDuration = 1f;
    }

    public override bool OnShapeshift(PlayerControl shapeshifter, PlayerControl target, bool shapeshifting)
    {
        if (shapeshifting)
        {
            Main.AllPlayerSpeed[target.PlayerId] = Main.MinSpeed;
            target.MarkDirtySettings();

            LateTask.New(() =>
            {
                Main.AllPlayerSpeed[target.PlayerId] = Main.RealOptionsData.GetFloat(FloatOptionNames.PlayerSpeedMod);
                target.MarkDirtySettings();
            }, FreezeDuration.GetFloat(), "FreezerFreezeDuration");

            if (target.AmOwner)
                Achievements.Type.TooCold.CompleteAfterGameEnd();
        }

        return false;
    }
}