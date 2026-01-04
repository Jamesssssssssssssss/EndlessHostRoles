namespace EHR.Roles;

internal class Magnet : AddonBase
{
    public override AddonTypes Type => AddonTypes.Helpful;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(19692, CustomRoles.Magnet, canSetNum: true, teamSpawnOptions: true);
    }
}