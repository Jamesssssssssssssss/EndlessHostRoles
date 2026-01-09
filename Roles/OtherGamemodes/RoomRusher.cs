using AmongUs.GameOptions;
using EHR.Gamemodes;
using EHR.Modules;

namespace EHR.Roles;

internal class RRPlayer : RoleBase
{
    public override CustomGamemodes GamemodeId => CustomGamemodes.RoomRush;
    public override CustomRoles RoleId => CustomRoles.RRPlayer;

    public override bool IsEnable => Options.CurrentGameMode == CustomGamemodes.RoomRush;

    public override void Init() { }

    public override void Add(byte playerId) { }

    public override void SetupCustomOption() { }

    public override void OnExitVent(PlayerControl pc, Vent vent)
    {
        RoomRush.VentLimit[pc.PlayerId]--;
        int newLimit = RoomRush.VentLimit[pc.PlayerId];
        Utils.SendRPC(CustomRPC.RoomRushDataSync, 2, newLimit, pc.PlayerId);
        if (newLimit <= 0) pc.RpcSetRoleGlobal(RoleTypes.Crewmate);
    }
}