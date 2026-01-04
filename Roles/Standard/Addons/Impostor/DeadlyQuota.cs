namespace EHR.Roles;

internal class DeadlyQuota : AddonBase
{
    public override AddonTypes Type => AddonTypes.ImpOnly;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(14650, CustomRoles.DeadlyQuota, canSetNum: true);

        Options.DQNumOfKillsNeeded = new IntegerOptionItem(14660, "DQNumOfKillsNeeded", new(1, 14, 1), 3, TabGroup.Addons)
            .SetParent(Options.CustomRoleSpawnChances[CustomRoles.DeadlyQuota]);
    }
}