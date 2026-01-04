using static EHR.Options;

namespace EHR.Roles;

internal class Gravestone : AddonBase
{
    public override AddonTypes Type => AddonTypes.Helpful;

    public override void SetupCustomOption()
    {
        SetupAdtRoleOptions(14000, CustomRoles.Gravestone, canSetNum: true, teamSpawnOptions: true);
    }
}