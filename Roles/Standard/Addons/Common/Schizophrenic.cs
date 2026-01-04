using static EHR.Options;

namespace EHR.Roles;

internal class Schizophrenic : AddonBase
{
    public override AddonTypes Type => AddonTypes.Mixed;

    public override void SetupCustomOption()
    {
        SetupAdtRoleOptions(14700, CustomRoles.Schizophrenic, canSetNum: true, teamSpawnOptions: true);

        DualVotes = new BooleanOptionItem(14712, "DualVotes", true, TabGroup.Addons)
            .SetParent(CustomRoleSpawnChances[CustomRoles.Schizophrenic]);
    }
}