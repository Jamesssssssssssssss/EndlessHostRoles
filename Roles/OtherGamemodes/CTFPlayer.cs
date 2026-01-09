using EHR.Gamemodes;

namespace EHR.Roles;

internal class CTFPlayer : RoleBase
{
    public override CustomGamemodes GamemodeId => CustomGamemodes.CaptureTheFlag;
    public override CustomRoles RoleId => CustomRoles.CTFPlayer;

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
        CaptureTheFlag.TryPickUpFlag(pc);
        return false;
    }
}