using static EHR.Options;

namespace EHR.Roles;

internal class Sunglasses : AddonBase
{
    public override AddonTypes Type => AddonTypes.Harmful;

    public override void SetupCustomOption()
    {
        SetupAdtRoleOptions(15450, CustomRoles.Sunglasses, canSetNum: true, teamSpawnOptions: true);

        SunglassesVision = new FloatOptionItem(15460, "SunglassesVision", new(0f, 5f, 0.05f), 0.75f, TabGroup.Addons)
            .SetParent(CustomRoleSpawnChances[CustomRoles.Sunglasses])
            .SetValueFormat(OptionFormat.Multiplier);
    }
}