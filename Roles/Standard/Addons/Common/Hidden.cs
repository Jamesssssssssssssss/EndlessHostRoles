namespace EHR.Roles;

public class Hidden : AddonBase
{
    public override AddonTypes Type => AddonTypes.Harmful;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(656600, CustomRoles.Hidden, canSetNum: true, teamSpawnOptions: true);
    }
}