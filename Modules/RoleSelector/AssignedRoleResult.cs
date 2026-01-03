using System.Collections.Generic;
using EHR;
using EHR.Roles;

public sealed class AssignedRoleResult
{
    public int PlayerId { get; init; }
    public CustomRoles Role { get; init; }
    public List<CustomRoles> Addons { get; init; } = [];
}
