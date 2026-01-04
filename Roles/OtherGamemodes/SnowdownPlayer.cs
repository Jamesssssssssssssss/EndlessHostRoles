using EHR.Gamemodes;

namespace EHR.Roles;

internal class SnowdownPlayer : RoleBase
{
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

    public override bool CanUseSabotage(PlayerControl pc)
    {
        return pc.IsAlive();
    }

    public override bool OnSabotage(PlayerControl pc)
    {
        if (Snowdown.Data.TryGetValue(pc.PlayerId, out Snowdown.PlayerData data))
            data.OnSabotage(pc);
        
        return false;
    }

    public override bool OnVanish(PlayerControl pc)
    {
        if (Snowdown.Data.TryGetValue(pc.PlayerId, out Snowdown.PlayerData data))
            data.OnVanish(pc);
        
        return false;
    }

    public override void OnPet(PlayerControl pc)
    {
        if (Snowdown.Data.TryGetValue(pc.PlayerId, out Snowdown.PlayerData data))
            data.OnPet(pc);
    }
}