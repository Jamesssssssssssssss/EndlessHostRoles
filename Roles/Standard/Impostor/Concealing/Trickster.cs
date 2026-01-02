using System.Collections.Generic;

namespace EHR.Roles;

internal class Trickster : RoleBase, IStandardRole
{
    public override bool IsEnable => false;

    public Team Faction => Team.Impostor;
    public RoleOptionType? Alignment => RoleOptionType.Impostor_Concealing;
    public IReadOnlyList<CustomRoles> IncompatibleRoles => [];

    public override void SetupCustomOption()
    {
        Options.SetupRoleOptions(4300, TabGroup.ImpostorRoles, CustomRoles.Trickster);
    }

    public override void Init() { }

    public override void Add(byte playerId) { }
}