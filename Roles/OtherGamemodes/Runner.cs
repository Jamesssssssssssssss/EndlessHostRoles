namespace EHR.Roles;

internal class Runner : RoleBase
{
    public override CustomGamemodes GamemodeId => CustomGamemodes.Speedrun;
    public override CustomRoles RoleId => CustomRoles.Runner;

    public override bool IsEnable => false;

    public override void Init() { }

    public override void Add(byte playerId) { }

    public override void SetupCustomOption() { }

    public override bool CanUseVent(PlayerControl pc, int ventId)
    {
        return !IsThisRole(pc);
    }
}