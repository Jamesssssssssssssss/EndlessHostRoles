using EHR.Gamemodes;

namespace EHR.Roles;

public class TMGPlayer : RoleBase
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

    public override bool OnVanish(PlayerControl pc)
    {
        TheMindGame.OnVanish(pc);
        return false;
    }
}