namespace EHR.Roles;

public class Blind : AddonBase
{
    public override AddonTypes Type => AddonTypes.Harmful;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(651600, CustomRoles.Blind, canSetNum: true, teamSpawnOptions: true);
    }
}