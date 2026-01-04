using static EHR.Options;

namespace EHR.Roles;

internal class Fool : AddonBase
{
    public override AddonTypes Type => AddonTypes.Harmful;

    public override void SetupCustomOption()
    {
        SetupAdtRoleOptions(19200, CustomRoles.Fool, canSetNum: true, teamSpawnOptions: true);
    }
}