namespace EHR.Roles;

internal class Mischievous : AddonBase
{
    public override AddonTypes Type => AddonTypes.Helpful;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(15160, CustomRoles.Mischievous, canSetNum: true);
    }
}