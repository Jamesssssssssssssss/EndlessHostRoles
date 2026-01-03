using System.Collections.Generic;
using System.Linq;

namespace EHR.Modules.RoleSelector;

public sealed class RoleSelectionEngine
{
    public List<AssignedRoleResult> Run(RoleLimits limits, List<PlayerControl> players)
    {
        var ctx = new RoleSelectionContext
        {
            AvailableRoles = [.. RoleRegistry.AllRoles.Where(r => r.RoleId.GetMode() > 0)],
            Assigned = [],
            Limits = limits,
            Players = players
        };

        // 1. Pre-any-assignment
        foreach (var role in ctx.AvailableRoles.ToList())
            role.PreAnyAssignment(ctx);

        // 2. Assignment loop
        foreach (var player in players)
            AssignRoleToPlayer(player, ctx);

        // 3. Post-all-roles
        foreach (var role in RoleRegistry.AllRoles)
            role.PostAllRoles(ctx);

        return ctx.Assigned;
    }

    private void AssignRoleToPlayer(PlayerControl player, RoleSelectionContext ctx)
    {
        foreach (var candidate in ctx.AvailableRoles.ToList())
        {
            // Run pre-each-role checks
            foreach (var role in RoleRegistry.AllRoles)
                role.PreEachRoleCheck(ctx with { Candidate = candidate });

            // If candidate was removed by a role, skip it
            if (!ctx.AvailableRoles.Contains(candidate))
                continue;

            // Assign it
            ctx.Assigned.Add(new AssignedRoleResult
            {
                PlayerId = player.PlayerId,
                Role = candidate.RoleId,
                Addons = []
            });

            ctx.AvailableRoles.Remove(candidate);
            return;
        }

        // Fallback: vanilla crewmate
        ctx.Assigned.Add(new AssignedRoleResult
        {
            PlayerId = player.PlayerId,
            Role = CustomRoles.Crewmate,
            Addons = []
        });
    }
}
