using System.Collections.Generic;
using EHR;
using EHR.Modules.RoleSelector;
using EHR.Roles;

public abstract class StandardRoleBase : RoleBase
{ 
    public virtual CustomRoles RoleId => ResolveRoleId();
    public abstract Team Faction { get; }
    public abstract RoleOptionType? Alignment { get; }
    public virtual IReadOnlyList<CustomRoles> IncompatibleRoles => [];

    public virtual void PreAnyAssignment(RoleSelectionContext ctx) { }
    public virtual void PreEachRoleCheck(RoleSelectionContext ctx) { }
    public virtual void PostAllRoles(RoleSelectionContext ctx) { }
}
