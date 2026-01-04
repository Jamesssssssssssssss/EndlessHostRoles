using System;
using System.Collections.Generic;
using System.Linq;
using EHR.Roles;

namespace EHR.Modules.RoleSelector;

public sealed class RoleSelectionEngine
{
    public List<AssignedResult> Run()
    {
        var ctx = new RoleSelectionContext
        {
            AvailableRoles = [.. RoleRegistry.AllRoles.Where(e => e.SpawnChance > 0)],
            AvailableAddons = [.. RoleRegistry.AllAddons.Where(e => e.SpawnChance > 0)],
            SelectedRoles = [],
            SelectedAddons = [],
            AssignedResult = [],
            AllPlayers = [.. Main.AllAlivePlayerControls],
            Limits = new RoleLimits(),
            XORPairs = Main.XORRoles
            // TODO XNorPairs
        };

        AssignGameMasters(ctx);

        // Validation before any role is selected
        foreach (var entry in ctx.AvailableRoles)
            entry.Role.PreAnyRolesSelected(ctx);

        // 2. Select each role
        SelectRoles(ctx);

        // 3. Validation after all roles are selected
        foreach (var entry in ctx.SelectedRoles)
            entry.Role.PostAllRolesSelected(ctx);

        return ctx.AssignedResult;
    }

    private void AssignGameMasters(RoleSelectionContext ctx)
    {
        var localPlayer = PlayerControl.LocalPlayer;
        // Players on the EAC banned list will be assigned as GM when opening rooms
        if (BanManager.CheckEACList(localPlayer.FriendCode, localPlayer.GetClient().GetHashedPuid()))
        {
            Logger.Warn("Host is dennab backwards", "RoleSelectionEngine => AssignGameMasters");
            AssignRoleToPlayer(ctx, localPlayer.PlayerId, CustomRoles.GM);
            ctx.AllPlayers.Remove(localPlayer);
        }

        if (Main.GM.Value)
        {
            Logger.Warn("Host: GM", "RoleSelectionEngine => AssignGameMasters");
            AssignRoleToPlayer(ctx, localPlayer.PlayerId, CustomRoles.GM);
            ctx.AllPlayers.RemoveAll(x => x.IsHost());
        }

        var spectators = ChatCommands.Spectators;
        ctx.AllPlayers.RemoveAll(x => spectators.Contains(x.PlayerId));
        foreach (var spectator in spectators) AssignRoleToPlayer(ctx, spectator, CustomRoles.GM);
    }


    private void AssignRoleToPlayer(RoleSelectionContext ctx, byte playerId, CustomRoles role, AddonBase addons = null)
    {
        ctx.AssignedResult.Add(AssignedResult.Create(playerId, role));
    }

    private void SelectRoles(RoleSelectionContext ctx)
    {
        var guaranteed = ctx.AvailableRoles
            .Where(r => r.SpawnChance >= 100)
            .Shuffle()
            .ToList();

        var nonGuaranteed = ctx.AvailableRoles
            .Where(r => r.SpawnChance < 100)
            .Shuffle()
            .ToList();

        var rolePool = guaranteed.Concat(nonGuaranteed).ToList();
        var rng = IRandom.Instance;

        foreach (var entry in rolePool)
        {
            ctx.Candidate = entry.Role;

            entry.Role.PreEachRoleSelection(ctx);


        }
    }

}
