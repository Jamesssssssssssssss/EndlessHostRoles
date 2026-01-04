namespace EHR.Roles;

internal class Reach : AddonBase
{
    public override AddonTypes Type => AddonTypes.Helpful;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(14600, CustomRoles.Reach, canSetNum: true, teamSpawnOptions: true);
    }
}