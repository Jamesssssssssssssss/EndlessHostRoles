using System.Collections.Generic;
using static EHR.Options;

namespace EHR.Roles;

internal class Lazy : AddonBase
{
    public static Dictionary<byte, Vector2> BeforeMeetingPositions = [];
    public override AddonTypes Type => AddonTypes.Helpful;

    public override void SetupCustomOption()
    {
        SetupAdtRoleOptions(14100, CustomRoles.Lazy, canSetNum: true);
    }
}