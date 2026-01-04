namespace EHR.Roles;

public class Shy : AddonBase
{
    public override AddonTypes Type => AddonTypes.Harmful;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(645890, CustomRoles.Shy, canSetNum: true, teamSpawnOptions: true);
    }
}