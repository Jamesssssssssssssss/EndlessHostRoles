namespace EHR.Roles;

public class Compelled : AddonBase
{
    public override AddonTypes Type => AddonTypes.Harmful;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(654980, CustomRoles.Compelled, canSetNum: true, teamSpawnOptions: true);
    }
}