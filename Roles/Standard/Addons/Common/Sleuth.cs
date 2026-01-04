namespace EHR.Roles;

internal class Sleuth : AddonBase
{
    public override AddonTypes Type => AddonTypes.Helpful;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(15150, CustomRoles.Sleuth, canSetNum: true, teamSpawnOptions: true);
    }
}