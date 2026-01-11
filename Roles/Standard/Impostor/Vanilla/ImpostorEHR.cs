using static EHR.Options;

namespace EHR.Roles;

internal class ImpostorEHR : RoleBase
{
    public override bool IsEnable => false;

    public override CustomRoles RoleId => CustomRoles.ImpostorEHR;
    public override CustomGamemodes GamemodeId => CustomGamemodes.Standard;

    public override void Add(byte playerId) { }
    public override void Init() { }

    public override void SetupCustomOption()
    {
        SetupRoleOptions(300, TabGroup.ImpostorRoles, CustomRoles.ImpostorEHR);
    }
}
