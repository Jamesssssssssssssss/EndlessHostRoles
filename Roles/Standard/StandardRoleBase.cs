using System.Collections.Generic;
using EHR;
using EHR.Modules.RoleSelector;
using EHR.Roles;

public abstract class StandardRoleBase : RoleBase
{ 
    public abstract Team Faction { get; }
    public abstract RoleOptionType? Alignment { get; }
    
    public virtual IReadOnlyList<CustomRoles> IncompatibleAddons => [];
}
