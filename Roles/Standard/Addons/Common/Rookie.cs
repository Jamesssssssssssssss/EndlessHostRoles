namespace EHR.Roles;

public class Rookie : AddonBase
{
    public override AddonTypes Type => AddonTypes.Harmful;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(649592, CustomRoles.Rookie, canSetNum: true, teamSpawnOptions: true);
    }
}