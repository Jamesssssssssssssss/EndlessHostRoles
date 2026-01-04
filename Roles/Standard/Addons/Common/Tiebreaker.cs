using static EHR.Options;

namespace EHR.Roles;

internal class Tiebreaker : AddonBase
{
    public override AddonTypes Type => AddonTypes.Mixed;

    public override void SetupCustomOption()
    {
        SetupAdtRoleOptions(14900, CustomRoles.Tiebreaker, canSetNum: true, teamSpawnOptions: true);
    }
}