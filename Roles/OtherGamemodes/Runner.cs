namespace EHR.Roles;

internal class Runner : RoleBase
{
    public override bool IsEnable => false;

    public override void Init() { }

    public override void Add(byte playerId) { }

    public override void SetupCustomOption() { }

    public override bool CanUseVent(PlayerControl pc, int ventId)
    {
        return !IsThisRole(pc);
    }
}