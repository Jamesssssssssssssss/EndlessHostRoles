using System.Collections.Generic;
namespace EHR.Roles;

public class Messenger : AddonBase
{
    public static HashSet<byte> Sent = [];
    public override AddonTypes Type => AddonTypes.Helpful;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(649392, CustomRoles.Messenger, canSetNum: true, teamSpawnOptions: true);
    }
}