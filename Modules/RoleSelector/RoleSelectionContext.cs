using System.Collections.Generic;
using System.Linq;

namespace EHR.Modules.RoleSelector;

public sealed record class RoleSelectionContext
{
    public List<StandardRoleBase> AvailableRoles { get; init; }
    public List<AssignedRoleResult> Assigned { get; init; }
    public List<PlayerControl> Players { get; init; }

    public RoleLimits Limits { get; init; }
    
    public StandardRoleBase? Candidate { get; set; }

    public void RemoveRole(CustomRoles roleId)
        => AvailableRoles.RemoveAll(r => r.RoleId == roleId);

    public bool IsAssigned(CustomRoles roleId)
        => Assigned.Any(a => a.Role == roleId);
}

