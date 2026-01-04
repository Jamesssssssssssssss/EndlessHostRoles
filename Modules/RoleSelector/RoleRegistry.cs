using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EHR.Roles;

namespace EHR.Modules.RoleSelector;

public static class RoleRegistry
{
    private static readonly List<RoleRegistryEntry> _allRoles;
    private static readonly List<AddonRegistryEntry> _allAddons;

    static RoleRegistry()
    {
        var asm = Assembly.GetExecutingAssembly();

        _allRoles = [.. asm.GetTypes()
            .Where(t => !t.IsAbstract && typeof(StandardRoleBase).IsAssignableFrom(t))
            .Select(t =>
            {
                var role = (StandardRoleBase)Activator.CreateInstance(t);

                return new RoleRegistryEntry
                {
                    Role = role,
                    MaxCount = role.RoleId.GetCount(),
                    SpawnChance = role.RoleId.GetMode()
                };
            }
            )];

        _allAddons = [.. asm.GetTypes()
            .Where(t => !t.IsAbstract && typeof(AddonBase).IsAssignableFrom(t))
            .Select(t =>
            {
                var addon = (AddonBase)Activator.CreateInstance(t);

                return new AddonRegistryEntry
                {
                    Addon = addon,
                    MaxCount = addon.AddonId.GetCount(),
                    SpawnChance = addon.AddonId.GetMode()
                    };
            }
            )];
    }

    public static IReadOnlyList<RoleRegistryEntry> AllRoles => _allRoles;
    public static IReadOnlyList<AddonRegistryEntry> AllAddons => _allAddons;
}

public sealed class RoleRegistryEntry
{
    public StandardRoleBase Role { get; init; }
    public int MaxCount { get; init; }
    public int SpawnChance { get; init; }
}

public sealed class AddonRegistryEntry
{
    public AddonBase Addon { get; init; }
    public int MaxCount { get; init; }
    public int SpawnChance { get; init; }
}