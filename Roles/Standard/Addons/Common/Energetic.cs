namespace EHR.Roles;

public class Energetic : AddonBase
{
    public override AddonTypes Type => AddonTypes.Helpful;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(644592, CustomRoles.Energetic, canSetNum: true, teamSpawnOptions: true);
    }
}