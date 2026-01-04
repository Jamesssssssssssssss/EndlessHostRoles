namespace EHR.Roles;

public class Fragile : AddonBase
{
    public override AddonTypes Type => AddonTypes.Harmful;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(645332, CustomRoles.Fragile, canSetNum: true, teamSpawnOptions: true);
    }
}