using System.Collections.Generic;
using System.Linq;
using AmongUs.GameOptions;
using EHR.Modules;
using UnityEngine;
using static EHR.Gamemodes.Deathrace;

namespace EHR.Roles;

internal class Racer : RoleBase
{
    public override CustomGamemodes GamemodeId => CustomGamemodes.Deathrace;
    public override CustomRoles RoleId => CustomRoles.Racer;
    public static bool On;

    public override bool IsEnable => On;

    public override void SetupCustomOption() { }

    public override void Init()
    {
        On = false;
    }

    public override void Add(byte playerId)
    {
        On = true;
    }

    public override bool OnVanish(PlayerControl pc)
    {
        UsePowerUp(pc);
        return false;
    }

    public static void UsePowerUp(PlayerControl pc)
    {
        if (!SpawnPowerUps || !Data.TryGetValue(pc.PlayerId, out var data) || data.PowerUps.Count == 0) return;
        PowerUp powerUp = data.PowerUps[0];
        pc.RPCPlayCustomSound("Line");
        data.PowerUps.RemoveAt(0);
        PlayerControl[] playersInRange = [.. Utils.GetPlayersInRadius(PowerUpEffectRange, pc.Pos()).Without(pc)];

        switch (powerUp)
        {
            case PowerUp.Smoke:
            {
                playersInRange = playersInRange.Where(x => !Mathf.Approximately(Main.AllPlayerSpeed[x.PlayerId], Main.MinSpeed)).ToArray();
                
                foreach (PlayerControl player in playersInRange)
                {
                    if (Main.AllPlayerSpeed[player.PlayerId] < 0f) Main.AllPlayerSpeed[player.PlayerId] += SmokeSpeedReduction;
                    else Main.AllPlayerSpeed[player.PlayerId] -= SmokeSpeedReduction;
                    
                    player.MarkDirtySettings();
                }
                
                LateTask.New(() =>
                {
                    foreach (PlayerControl player in playersInRange)
                    {
                        if (player == null) continue;
                        
                        if (Main.AllPlayerSpeed[player.PlayerId] < 0f) Main.AllPlayerSpeed[player.PlayerId] -= SmokeSpeedReduction;
                        else Main.AllPlayerSpeed[player.PlayerId] += SmokeSpeedReduction;
                        
                        player.MarkDirtySettings();
                    }
                }, PowerUpEffectDuration, $"Smoke Revert ({Main.AllPlayerNames.GetValueOrDefault(pc.PlayerId, $"ID {pc.PlayerId}")})");
                break;
            }
            case PowerUp.EnergyDrink:
            {
                if (Main.AllPlayerSpeed[pc.PlayerId] < 0f) Main.AllPlayerSpeed[pc.PlayerId] -= EnergyDrinkSpeedIncreasement;
                else Main.AllPlayerSpeed[pc.PlayerId] += EnergyDrinkSpeedIncreasement;
                pc.MarkDirtySettings();
                
                LateTask.New(() =>
                {
                    if (pc == null || Mathf.Approximately(Main.AllPlayerSpeed[pc.PlayerId], Main.RealOptionsData.GetFloat(FloatOptionNames.PlayerSpeedMod)) || Mathf.Approximately(Main.AllPlayerSpeed[pc.PlayerId], Main.MinSpeed)) return;
                    if (Main.AllPlayerSpeed[pc.PlayerId] < 0f) Main.AllPlayerSpeed[pc.PlayerId] += EnergyDrinkSpeedIncreasement;
                    else Main.AllPlayerSpeed[pc.PlayerId] -= EnergyDrinkSpeedIncreasement;
                    pc.MarkDirtySettings();
                }, PowerUpEffectDuration, $"Energy Drink Revert ({Main.AllPlayerNames.GetValueOrDefault(pc.PlayerId, $"ID {pc.PlayerId}")})");
                break;
            }
            case PowerUp.Grenade:
            {
                foreach (PlayerControl player in playersInRange)
                {
                    if (!Main.PlayerStates.TryGetValue(player.PlayerId, out var state)) return;
                    state.IsBlackOut = true;
                    player.RPCPlayCustomSound("FlashBang");
                    player.MarkDirtySettings();
                }
                
                LateTask.New(() =>
                {
                    foreach (PlayerControl player in playersInRange)
                    {
                        if (player == null || !Main.PlayerStates.TryGetValue(player.PlayerId, out var state) || !state.IsBlackOut) continue;
                        state.IsBlackOut = false;
                        RPC.PlaySoundRPC(player.PlayerId, Sounds.TaskComplete);
                        player.MarkDirtySettings();
                    }
                }, PowerUpEffectDuration, $"Grenade Revert ({Main.AllPlayerNames.GetValueOrDefault(pc.PlayerId, $"ID {pc.PlayerId}")})");
                break;
            }
            case PowerUp.Ice:
            {
                foreach (PlayerControl player in playersInRange)
                {
                    Main.AllPlayerSpeed[player.PlayerId] *= -1;
                    RPC.PlaySoundRPC(player.PlayerId, Sounds.SabotageSound);
                    player.MarkDirtySettings();
                }
                
                LateTask.New(() =>
                {
                    foreach (PlayerControl player in playersInRange)
                    {
                        if (player == null || Main.AllPlayerSpeed[player.PlayerId] >= 0f) continue;
                        Main.AllPlayerSpeed[player.PlayerId] *= -1;
                        RPC.PlaySoundRPC(player.PlayerId, Sounds.TaskComplete);
                        player.MarkDirtySettings();
                    }
                }, PowerUpEffectDuration, $"Ice Revert ({Main.AllPlayerNames.GetValueOrDefault(pc.PlayerId, $"ID {pc.PlayerId}")})");
                break;
            }
        }
    }

}