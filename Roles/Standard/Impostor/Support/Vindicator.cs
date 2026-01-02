using System.Collections.Generic;
using static EHR.Options;

namespace EHR.Roles;

internal class Vindicator : RoleBase, IStandardRole
{
    public override bool IsEnable => false;

    public Team Faction => Team.Impostor;
    public RoleOptionType? Alignment => RoleOptionType.Impostor_Support;
    public IReadOnlyList<CustomRoles> IncompatibleRoles => [];

    public override void SetupCustomOption()
    {
        SetupRoleOptions(3400, TabGroup.ImpostorRoles, CustomRoles.Vindicator);

        VindicatorAdditionalVote = new IntegerOptionItem(3410, "MayorAdditionalVote", new(1, 30, 1), 1, TabGroup.ImpostorRoles)
            .SetParent(CustomRoleSpawnChances[CustomRoles.Vindicator])
            .SetValueFormat(OptionFormat.Votes);

        VindicatorHideVote = new BooleanOptionItem(3411, "MayorHideVote", false, TabGroup.ImpostorRoles)
            .SetParent(CustomRoleSpawnChances[CustomRoles.Vindicator]);
    }

    public override void Init() { }

    public override void Add(byte playerId) { }
}