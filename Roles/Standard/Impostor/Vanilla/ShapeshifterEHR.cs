using static EHR.Options;

namespace EHR.Roles;

internal class ShapeshifterEHR : RoleBase
{
    public static OptionItem ShapeshiftCD;
    public static OptionItem ShapeshiftDur;

    public override bool IsEnable => false;

    public override CustomRoles RoleId => CustomRoles.ShapeshifterEHR;
    public override CustomGamemodes GamemodeId => CustomGamemodes.Standard;

    public override void Add(byte playerId) { }
    public override void Init() { }

    public override void SetupCustomOption()
    {
        SetupRoleOptions(400, TabGroup.ImpostorRoles, CustomRoles.ShapeshifterEHR);

        ShapeshiftCD =
            new FloatOptionItem(402, "ShapeshiftCooldown", new(1f, 180f, 1f), 30f, TabGroup.ImpostorRoles)
                .SetParent(CustomRoleSpawnChances[CustomRoles.ShapeshifterEHR])
                .SetValueFormat(OptionFormat.Seconds);

        ShapeshiftDur =
            new FloatOptionItem(403, "ShapeshiftDuration", new(1f, 60f, 1f), 10f, TabGroup.ImpostorRoles)
                .SetParent(CustomRoleSpawnChances[CustomRoles.ShapeshifterEHR])
                .SetValueFormat(OptionFormat.Seconds);
    }
}
