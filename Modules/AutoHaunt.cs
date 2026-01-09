using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AmongUs.GameOptions;
using EHR.Gamemodes;
using EHR.Roles;
using UnityEngine;

namespace EHR.Modules;

public static class AutoHaunt
{
    private static PlayerControl GetPreferredHauntTarget()
    {
        IEnumerable<PlayerControl> validPCs = Main.AllAlivePlayerControls.Where(x => !AFKDetector.PlayerData.ContainsKey(x.PlayerId));

        return Options.CurrentGameMode switch
        {
            CustomGamemodes.Standard => validPCs.OrderByDescending(x => x.GetCustomRole() is CustomRoles.Workaholic or CustomRoles.Snitch && x.GetTaskState().RemainingTasksCount <= 2).ThenByDescending(x => x.Is(CustomRoleTypes.Coven)).ThenByDescending(x => x.IsNeutralKiller()).ThenByDescending(x => x.IsImpostor()).ThenByDescending(x => x.GetCustomRole().IsNeutral()).FirstOrDefault(),
            CustomGamemodes.SoloPVP => validPCs.Where(x => SoloPVP.IsAliveInSoloPVP(x)).MinBy(x => SoloPVP.GetRankFromScore(x.PlayerId)),
            CustomGamemodes.FFA => validPCs.MaxBy(x => FreeForAll.KillCount.GetValueOrDefault(x.PlayerId, 0)),
            CustomGamemodes.StopAndGo => validPCs.MaxBy(x => x.GetTaskState().CompletedTasksCount),
            CustomGamemodes.HotPotato => HotPotato.GetState().HolderID.GetPlayer(),
            CustomGamemodes.HideAndSeek => validPCs.OrderByDescending(x => x.GetCustomRole() is CustomRoles.Venter or CustomRoles.Dasher).ThenByDescending(x => CustomHnS.PlayerRoles.TryGetValue(x.PlayerId, out (IHideAndSeekRole Interface, CustomRoles Role) info) && info.Interface.Team == Team.Impostor).ThenByDescending(x => CustomHnS.PlayerRoles.TryGetValue(x.PlayerId, out (IHideAndSeekRole Interface, CustomRoles Role) info) && info.Interface.Team == Team.Neutral).FirstOrDefault(),
            CustomGamemodes.Speedrun => Speedrun.CanKill.Count > 0 ? Speedrun.CanKill.ToValidPlayers().RandomElement() : validPCs.MaxBy(x => x.GetTaskState().CompletedTasksCount),
            CustomGamemodes.CaptureTheFlag => validPCs.OrderByDescending(x => CaptureTheFlag.IsCarrier(x.PlayerId)).ThenByDescending(x => CaptureTheFlag.GetFlagTime(x.PlayerId)).ThenByDescending(x => CaptureTheFlag.GetTagCount(x.PlayerId)).FirstOrDefault(),
            CustomGamemodes.RoomRush => RoomRush.PointsSystem ? validPCs.MaxBy(x => RoomRush.GetPoints(x.PlayerId)) : validPCs.RandomElement(),
            CustomGamemodes.KingOfTheZones => validPCs.MaxBy(x => KingOfTheZones.GetZoneTime(x.PlayerId)),
            CustomGamemodes.Deathrace => validPCs.MaxBy(x => Deathrace.Data.TryGetValue(x.PlayerId, out var drData) ? drData.Lap : 0),
            CustomGamemodes.Snowdown => validPCs.Where(x => Snowdown.Data.ContainsKey(x.PlayerId)).Select(x => (pc: x, data: Snowdown.Data[x.PlayerId])).OrderByDescending(x => x.data.Points).ThenBy(x => x.data.SnowballGainInterval).ThenByDescending(x => x.data.Coins).ThenByDescending(x => x.data.SnowballsReady).Select(x => x.pc).FirstOrDefault(),
            _ => validPCs.RandomElement()
        };
    }

    public static void Start()
    {
        Main.Instance.StartCoroutine(AutoHauntCoroutine());
        return;

        static IEnumerator AutoHauntCoroutine()
        {
            while (Main.AutoHaunt.Value)
            {
                if (HudManager.InstanceExists && GameStates.IsInTask && !ExileController.Instance && !AntiBlackout.SkipTasks && !PlayerControl.LocalPlayer.IsAlive() && PlayerControl.LocalPlayer.Data.RoleType is RoleTypes.CrewmateGhost or RoleTypes.ImpostorGhost && !ExtendedPlayerControl.TempExiled.Contains(PlayerControl.LocalPlayer.PlayerId))
                {
                    if (HauntMenuMinigameStartPatch.Instance != null)
                    {
                        PlayerControl currentTarget = HauntMenuMinigameStartPatch.Instance.HauntTarget;
                        PlayerControl preferredTarget = GetPreferredHauntTarget();

                        if (preferredTarget != null && currentTarget != preferredTarget)
                            HauntMenuMinigameSetHauntTargetPatch.Prefix(HauntMenuMinigameStartPatch.Instance, preferredTarget);
                    }
                    else
                        HudManager.Instance.AbilityButton.DoClick();
                }

                yield return new WaitForSeconds(5f);
            }

            if (GameStates.IsInTask && !ExileController.Instance && !AntiBlackout.SkipTasks && !PlayerControl.LocalPlayer.IsAlive() && HauntMenuMinigameStartPatch.Instance != null)
                HauntMenuMinigameSetHauntTargetPatch.Prefix(HauntMenuMinigameStartPatch.Instance, null);
        }
    }
}