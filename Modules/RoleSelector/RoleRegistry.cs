using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EHR.Modules.RoleSelector;

public static class RoleRegistry
{
    private static readonly List<StandardRoleBase> _roles;

    static RoleRegistry()
    {
        _roles = [.. Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => !t.IsAbstract && typeof(StandardRoleBase).IsAssignableFrom(t))
            .Select(t => (StandardRoleBase)Activator.CreateInstance(t))];
    }

    public static IReadOnlyList<StandardRoleBase> AllRoles => _roles;
}
