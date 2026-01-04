using static EHR.Options;

namespace EHR.Roles;

internal class Seer : AddonBase
{
    public override AddonTypes Type => AddonTypes.Helpful;

    public override void SetupCustomOption()
    {
        SetupAdtRoleOptions(14800, CustomRoles.Seer, canSetNum: true, teamSpawnOptions: true);
    }
}