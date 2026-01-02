using System.Collections.Generic;
using EHR;
using EHR.Modules.RoleSelector;

public interface IStandardRole
{
    Team Faction { get; }
    RoleOptionType? Alignment { get; }

    IReadOnlyList<CustomRoles> IncompatibleRoles { get; }

    static void PreFilter(RoleSelectionContext ctx) { }
    static void PreLimit(RoleSelectionContext ctx) { }
    static void PostLimit(RoleSelectionContext ctx) { }
    static void PreAssignment(RoleSelectionContext ctx) { }
    static void PostAssignment(RoleSelectionContext ctx) { }
}
