using static EHR.Options;

namespace EHR.Roles;

internal class Rascal : AddonBase
{
    public override AddonTypes Type => AddonTypes.Harmful;

    public override void SetupCustomOption()
    {
        SetupAdtRoleOptions(15600, CustomRoles.Rascal, canSetNum: true, tab: TabGroup.Addons, teamSpawnOptions: true);

        RascalAppearAsMadmate = new BooleanOptionItem(15610, "RascalAppearAsMadmate", true, TabGroup.Addons)
            .SetParent(CustomRoleSpawnChances[CustomRoles.Rascal]);
    }
}