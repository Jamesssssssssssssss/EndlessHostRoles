using System.Collections.Generic;

namespace EHR.Roles;

internal class Godfather : RoleBase, IStandardRole
{
    public static byte GodfatherTarget = byte.MaxValue;
    public static bool On;
    public override bool IsEnable => On;

    public Team Faction => Team.Impostor;
    public RoleOptionType? Alignment => RoleOptionType.Impostor_Support;
    public IReadOnlyList<CustomRoles> IncompatibleRoles => [];

    public override void SetupCustomOption()
    {
        Options.SetupRoleOptions(648400, TabGroup.ImpostorRoles, CustomRoles.Godfather);
        Options.GodfatherCancelVote = Options.CreateVoteCancellingUseSetting(648402, CustomRoles.Godfather, TabGroup.ImpostorRoles);
    }

    public override void Add(byte playerId)
    {
        On = true;
    }

    public override void Init()
    {
        On = false;
    }

    public override bool OnVote(PlayerControl voter, PlayerControl target)
    {
        if (Starspawn.IsDayBreak) return false;
        if (voter == null || target == null || voter.PlayerId == target.PlayerId || Main.DontCancelVoteList.Contains(voter.PlayerId)) return false;

        GodfatherTarget = target.PlayerId;
        Main.DontCancelVoteList.Add(voter.PlayerId);
        return true;
    }

    public override void OnMeetingShapeshift(PlayerControl shapeshifter, PlayerControl target)
    {
        OnVote(shapeshifter, target);
    }
}