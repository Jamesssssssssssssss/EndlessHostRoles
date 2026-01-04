using static EHR.Options;

namespace EHR.Roles;

internal class Autopsy : AddonBase
{
    public override AddonTypes Type => AddonTypes.Helpful;

    public override void SetupCustomOption()
    {
        SetupAdtRoleOptions(13600, CustomRoles.Autopsy, canSetNum: true, teamSpawnOptions: true);
    }
}