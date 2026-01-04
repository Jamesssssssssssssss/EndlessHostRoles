using System.Collections.Generic;
using System.Linq;
using EHR.Roles;

public sealed class AssignedResult
{
    public byte PlayerId { get; init; }
    public CustomRoles Role { get; init; }
    public List<CustomRoles> Addons { get; init; } = [];

    public static AssignedResult Create(
        byte player,
        CustomRoles role,
        IEnumerable<CustomRoles> addons = null)
    {
        return new AssignedResult
        {
            PlayerId = player,
            Role = role,
            Addons = addons?.ToList() ?? []
        };
    }
}
