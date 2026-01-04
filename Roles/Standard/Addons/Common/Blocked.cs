namespace EHR.Roles;

public class Blocked : AddonBase
{
    public override AddonTypes Type => AddonTypes.Harmful;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(646100, CustomRoles.Blocked, canSetNum: true, teamSpawnOptions: true);
    }
}