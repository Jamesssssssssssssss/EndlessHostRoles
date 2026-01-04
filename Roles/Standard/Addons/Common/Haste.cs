namespace EHR.Roles;

internal class Haste : AddonBase
{
    public override AddonTypes Type => AddonTypes.Helpful;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(14550, CustomRoles.Haste, canSetNum: true, teamSpawnOptions: true);
    }
}