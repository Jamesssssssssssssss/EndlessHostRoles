namespace EHR.Roles;

public class Anchor : AddonBase
{
    public override AddonTypes Type => AddonTypes.Harmful;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(649092, CustomRoles.Anchor, canSetNum: true, teamSpawnOptions: true);
    }
}