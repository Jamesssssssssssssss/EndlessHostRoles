namespace EHR.Roles;

internal class NotAssigned : RoleBase
{
    public static bool On;

    public override bool IsEnable => On;

    public override CustomGamemodes GamemodeId => CustomGamemodes.All;
    public override CustomRoles RoleId => CustomRoles.NotAssigned;

    public override void SetupCustomOption() { }

    public override void Init()
    {
        On = false;
    }

    public override void Add(byte playerId)
    {
        On = true;
    }
}