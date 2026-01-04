namespace EHR.Roles;

internal class Taskcounter : AddonBase
{
    public override AddonTypes Type => AddonTypes.ImpOnly;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(14370, CustomRoles.Taskcounter, canSetNum: true);
    }
}