using static EHR.Options;

namespace EHR.Roles;

internal class Glow : AddonBase
{
    public override AddonTypes Type => AddonTypes.Mixed;

    public override void SetupCustomOption()
    {
        SetupAdtRoleOptions(14020, CustomRoles.Glow, canSetNum: true, teamSpawnOptions: true);
    }
}