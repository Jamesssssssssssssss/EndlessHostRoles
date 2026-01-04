namespace EHR.Roles;

public class Trainee : AddonBase
{
    public override AddonTypes Type => AddonTypes.Harmful;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(647842, CustomRoles.Trainee, canSetNum: true, teamSpawnOptions: true);
    }
}