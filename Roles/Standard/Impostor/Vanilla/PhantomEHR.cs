using System.Collections.Generic;
using AmongUs.GameOptions;

namespace EHR.Roles;

public class PhantomEHR : StandardRoleBase
{
    public static bool On;

    public override bool IsEnable => On;

    public override CustomGamemodes GamemodeId => CustomGamemodes.Standard;
    public override CustomRoles RoleId => CustomRoles.PhantomEHR;
    public override Team Faction => Team.Impostor;
    public override RoleOptionType? Alignment => null;

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
        pc.RpcMakeInvisible(phantom: true);
        LateTask.New(() =>
        {
            if (ReportDeadBodyPatch.MeetingStarted || GameStates.IsMeeting) return;
            pc.RpcMakeVisible(phantom: true);
            pc.RpcResetAbilityCooldown();
        }, Main.RealOptionsData.GetFloat(FloatOptionNames.PhantomDuration), "PhantomEHR Appear");
        return false;
    }
}