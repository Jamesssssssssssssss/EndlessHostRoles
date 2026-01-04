using static EHR.Options;

namespace EHR.Roles;

internal class Necroview : AddonBase
{
    public override AddonTypes Type => AddonTypes.Helpful;

    public override void SetupCustomOption()
    {
        SetupAdtRoleOptions(14400, CustomRoles.Necroview, canSetNum: true, teamSpawnOptions: true);
    }
}