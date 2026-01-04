namespace EHR.Roles;

internal class Stealer : AddonBase
{
    public override AddonTypes Type => AddonTypes.ImpOnly;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(16100, CustomRoles.Stealer, canSetNum: true, tab: TabGroup.Addons);

        Options.VotesPerKill = new FloatOptionItem(16110, "VotesPerKill", new(0.1f, 90f, 0.1f), 0.5f, TabGroup.Addons)
            .SetParent(Options.CustomRoleSpawnChances[CustomRoles.Stealer]);
    }
}