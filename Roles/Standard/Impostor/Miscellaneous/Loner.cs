using System;
using System.Collections.Generic;
using System.Linq;
using EHR.Modules;

namespace EHR.Roles;

public class Loner : StandardRoleBase
{
    public static bool On;

    public override bool IsEnable => On;

    public byte PickedPlayer;
    public CustomRoles PickedRole;
    public bool Done;

    public override Team Faction => Team.Impostor;
    public override RoleOptionType? Alignment => RoleOptionType.Impostor_Miscellaneous;

    public override void SetupCustomOption()
    {
        StartSetup(655400);
    }

    public override void Init()
    {
        On = false;
    }

    public override void Add(byte playerId)
    {
        On = true;
        PickedPlayer = byte.MaxValue;
        PickedRole = CustomRoles.Crewmate;
        Done = false;
    }

    public override void OnMeetingShapeshift(PlayerControl shapeshifter, PlayerControl target)
    {
        if (Starspawn.IsDayBreak) return;
        if (shapeshifter == null || target == null || shapeshifter.PlayerId == target.PlayerId || Done) return;

        PickedPlayer = target.PlayerId;
        PickedRole = Enum.GetValues<CustomRoles>().Where(x => x.IsImpostor() && !x.IsVanilla() && !CustomRoleSelector.RoleResult.ContainsValue(x) && x.GetMode() != 0).RandomElement();
        if (PickedRole == CustomRoles.Crewmate) PickedRole = CustomRoles.ImpostorEHR;

        Utils.SendMessage("\n", shapeshifter.PlayerId, string.Format(Translator.GetString("Loner.Picked"), PickedPlayer.ColoredPlayerName(), PickedRole.ToColoredString()));
    }

    public override void AfterMeetingTasks()
    {
        var pc = PickedPlayer.GetPlayer();
        
        if (!Done && PickedPlayer != byte.MaxValue && PickedRole != CustomRoles.Crewmate && pc != null)
        {
            Done = true;
            pc.RpcSetCustomRole(PickedRole);
            pc.RpcChangeRoleBasis(PickedRole);
        }
    }
}