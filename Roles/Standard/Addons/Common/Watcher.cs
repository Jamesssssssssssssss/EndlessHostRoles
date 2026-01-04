using static EHR.Options;

namespace EHR.Roles;

internal class Watcher : AddonBase
{
    public override AddonTypes Type => AddonTypes.Helpful;

    public override void SetupCustomOption()
    {
        SetupAdtRoleOptions(15000, CustomRoles.Watcher, canSetNum: true, teamSpawnOptions: true);
    }
}