using AmongUs.GameOptions;
using static EHR.Options;

namespace EHR.Roles;

internal class PhantomEHR : StandardRoleBase
{
    public static bool On;
    public static OptionItem PhantomCooldown;
    public static OptionItem PhantomDuration;

    public override bool IsEnable => On;

    public override CustomGamemodes GamemodeId => CustomGamemodes.Standard;
    public override CustomRoles RoleId => CustomRoles.PhantomEHR;
    public override Team Faction => Team.Impostor;
    public override RoleOptionType? Alignment => null;

    public override void SetupCustomOption() 
    {
        SetupRoleOptions(350, TabGroup.ImpostorRoles, CustomRoles.PhantomEHR);

        PhantomCooldown = new FloatOptionItem(352, "PhantomCooldown", new(1f, 180f, 1f), 30f, TabGroup.ImpostorRoles)
            .SetParent(CustomRoleSpawnChances[CustomRoles.PhantomEHR])
            .SetValueFormat(OptionFormat.Seconds);

        PhantomDuration = new FloatOptionItem(353, "PhantomDuration", new(1f, 60f, 1f), 10f, TabGroup.ImpostorRoles)
            .SetParent(CustomRoleSpawnChances[CustomRoles.PhantomEHR])
            .SetValueFormat(OptionFormat.Seconds);
    }

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