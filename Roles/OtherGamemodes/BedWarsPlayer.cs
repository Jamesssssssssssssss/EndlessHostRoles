using AmongUs.GameOptions;
using EHR.Gamemodes;

namespace EHR.Roles;

internal class BedWarsPlayer : RoleBase
{
    private static bool On;

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

    public override void ApplyGameOptions(IGameOptions opt, byte playerId)
    {
        BedWars.ApplyGameOptions(opt, playerId);
    }

    public override bool CanUseImpostorVentButton(PlayerControl pc)
    {
        return BedWars.CanUseImpostorVentButton(pc);
    }

    public override bool OnVanish(PlayerControl pc)
    {
        return BedWars.OnVanish(pc);
    }

    public override void OnPet(PlayerControl pc)
    {
        BedWars.OnPet(pc);
    }

    public override void OnExitVent(PlayerControl pc, Vent vent)
    {
        BedWars.OnExitVent(pc, vent);
    }
}