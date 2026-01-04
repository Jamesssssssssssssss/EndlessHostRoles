using static EHR.Options;

namespace EHR.Roles;

internal class Disregarded : AddonBase
{
    public override AddonTypes Type => AddonTypes.Harmful;

    public override void SetupCustomOption()
    {
        SetupAdtRoleOptions(15300, CustomRoles.Disregarded, canSetNum: true, teamSpawnOptions: true);
    }
}