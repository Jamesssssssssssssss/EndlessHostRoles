namespace EHR.Roles;

public class Aide : AddonBase
{
    public override AddonTypes Type => AddonTypes.ImpOnly;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(646000, CustomRoles.Aide, canSetNum: true);
    }
}