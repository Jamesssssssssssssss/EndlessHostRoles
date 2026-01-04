namespace EHR.Roles;

public class Unbound : AddonBase
{
    public override AddonTypes Type => AddonTypes.Harmful;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(653900, CustomRoles.Unbound, canSetNum: true, teamSpawnOptions: true);
    }
}