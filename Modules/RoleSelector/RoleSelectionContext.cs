using System.Collections.Generic;

namespace EHR.Modules.RoleSelector;

internal class RoleSelectionContext
{
    public List<PlayerControl> Players;
    public Dictionary<RoleAssignType, List<RoleAssignInfo>> Pools;
    public Dictionary<byte, CustomRoles> FinalRoles;
    public Dictionary<byte, List<CustomRoles>> FinalAddons;
}
