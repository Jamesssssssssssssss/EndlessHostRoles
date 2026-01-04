using static EHR.Options;

namespace EHR.Roles;

internal class Loyal : AddonBase
{
    public override AddonTypes Type => AddonTypes.Mixed;

    public override void SetupCustomOption()
    {
        SetupAdtRoleOptions(15500, CustomRoles.Loyal, canSetNum: true);

        ImpCanBeLoyal = new BooleanOptionItem(15510, "ImpCanBeLoyal", true, TabGroup.Addons)
            .SetParent(CustomRoleSpawnChances[CustomRoles.Loyal]);

        CrewCanBeLoyal = new BooleanOptionItem(15511, "CrewCanBeLoyal", true, TabGroup.Addons)
            .SetParent(CustomRoleSpawnChances[CustomRoles.Loyal]);
    }
}