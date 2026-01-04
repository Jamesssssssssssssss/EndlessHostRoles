namespace EHR.Roles;

internal class Swift : AddonBase
{
    public override AddonTypes Type => AddonTypes.ImpOnly;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(16050, CustomRoles.Swift, canSetNum: true, tab: TabGroup.Addons);
    }
}