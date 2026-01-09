using System.Collections.Generic;

namespace EHR.Roles;

internal class Trickster : StandardRoleBase
{
    public override bool IsEnable => false;

    public override CustomGamemodes GamemodeId => CustomGamemodes.Standard;
    public override CustomRoles RoleId => CustomRoles.Trickster;
    public override Team Faction => Team.Impostor;
    public override RoleOptionType? Alignment => RoleOptionType.Impostor_Concealing;

    public override void SetupCustomOption()
    {
        Options.SetupRoleOptions(4300, TabGroup.ImpostorRoles, CustomRoles.Trickster);
    }

    public override void Init() { }

    public override void Add(byte playerId) { }
}