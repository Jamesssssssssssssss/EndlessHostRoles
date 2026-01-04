namespace EHR.Roles;

public class AntiTP : AddonBase
{
    public override AddonTypes Type => AddonTypes.Mixed;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(16892, CustomRoles.AntiTP, canSetNum: true, teamSpawnOptions: true);
    }
}