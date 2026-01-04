using System;
using System.Collections.Generic;
using System.Linq;
using EHR.Roles;

namespace EHR.Modules.RoleSelector;

public sealed record class RoleSelectionContext
{
    public List<RoleRegistryEntry> AvailableRoles { get; init; }
    public List<AddonRegistryEntry> AvailableAddons { get; init; }
    public List<RoleRegistryEntry> SelectedRoles { get; init; }
    public List<AddonRegistryEntry> SelectedAddons { get; init; }
    public List<AssignedResult> AssignedResult { get; init; }
    public List<PlayerControl> AllPlayers { get; init; }

    public RoleLimits Limits { get; init; }
    
    public StandardRoleBase Candidate { get; set; }
    public List<(CustomRoles, CustomRoles)> XORPairs { get; internal set; }

    public void RemoveRoleFromPool(CustomRoles roleId)
        => AvailableRoles.RemoveAll(r => r.Role.RoleId == roleId);

    public void RemoveAddonFromPool(CustomRoles addonId)
    => AvailableAddons.RemoveAll(r => r.Addon.AddonId == addonId);
}

