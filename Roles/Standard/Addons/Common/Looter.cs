namespace EHR.Roles;

public class Looter : AddonBase
{
    public override AddonTypes Type => AddonTypes.Mixed;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(656500, CustomRoles.Looter, canSetNum: true, teamSpawnOptions: true);
    }
}