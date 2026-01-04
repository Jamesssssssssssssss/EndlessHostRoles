namespace EHR.Roles;

internal class Avenger : AddonBase
{
    public override AddonTypes Type => AddonTypes.Harmful;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(15100, CustomRoles.Avenger, canSetNum: true, teamSpawnOptions: true);
    }
}