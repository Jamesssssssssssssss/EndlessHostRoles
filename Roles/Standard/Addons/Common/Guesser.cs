using UnityEngine;
using static EHR.Options;

namespace EHR.Roles;

internal class Guesser : AddonBase
{
    public static OptionItem GCanGuessAdt;
    public static OptionItem GTryHideMsg;
    public override AddonTypes Type => AddonTypes.Helpful;

    public override void SetupCustomOption()
    {
        SetupAdtRoleOptions(19100, CustomRoles.Guesser, canSetNum: true, tab: TabGroup.Addons, teamSpawnOptions: true);

        GCanGuessAdt = new BooleanOptionItem(19110, "GCanGuessAdt", false, TabGroup.Addons)
            .SetParent(CustomRoleSpawnChances[CustomRoles.Guesser]);

        GTryHideMsg = new BooleanOptionItem(19111, "GuesserTryHideMsg", true, TabGroup.Addons)
            .SetParent(CustomRoleSpawnChances[CustomRoles.Guesser])
            .SetColor(Color.green);
    }
}