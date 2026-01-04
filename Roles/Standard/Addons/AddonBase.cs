using System;
using System.Collections.Generic;
using EHR.Modules.RoleSelector;

namespace EHR.Roles;

public abstract class AddonBase
{
    public virtual CustomRoles AddonId => ResolveRoleId();
    public abstract AddonTypes Type { get; }
    public abstract void SetupCustomOption();
    public virtual IReadOnlyList<CustomRoles> IncompatibleRoles => [];
    public virtual IReadOnlyList<CustomRoles> IncompatibleAddons => [];

    public virtual void PreAnythingSelected(RoleSelectionContext ctx) { }

    private CustomRoles ResolveRoleId()
    {
        return Enum.Parse<CustomRoles>(GetType().Name, ignoreCase: true);
    }
}