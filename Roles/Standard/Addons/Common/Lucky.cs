using static EHR.Options;

namespace EHR.Roles;

internal class Lucky : AddonBase
{
    public override AddonTypes Type => AddonTypes.Mixed;

    public override void SetupCustomOption()
    {
        SetupAdtRoleOptions(14300, CustomRoles.Lucky, canSetNum: true, teamSpawnOptions: true);

        LuckyProbability = new IntegerOptionItem(14310, "LuckyProbability", new(0, 100, 5), 50, TabGroup.Addons)
            .SetParent(CustomRoleSpawnChances[CustomRoles.Lucky])
            .SetValueFormat(OptionFormat.Percent);
    }
}