namespace EHR.Roles;

public class Concealer : AddonBase
{
    public override AddonTypes Type => AddonTypes.ImpOnly;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(656200, CustomRoles.Concealer, canSetNum: true);
    }
}