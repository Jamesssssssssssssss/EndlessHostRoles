using System.Collections.Generic;
using static EHR.Options;

namespace EHR.Roles;

public class Ritualist : StandardRoleBase
{
    private const int Id = 13000;

    public static OptionItem KillCooldown;
    public static OptionItem RitualMaxCount;
    public static OptionItem CanVent;
    public static OptionItem HasImpostorVision;

    public override bool IsEnable => false;

    public override CustomGamemodes GamemodeId => CustomGamemodes.Standard;
    public override CustomRoles RoleId => CustomRoles.Ritualist;
    public override Team Faction => Team.Neutral;
    public override RoleOptionType? Alignment => RoleOptionType.Neutral_Killing;

    public override void SetupCustomOption()
    {
        SetupRoleOptions(Id, TabGroup.NeutralRoles, CustomRoles.Ritualist);

        KillCooldown = new FloatOptionItem(Id + 10, "KillCooldown", new(0f, 180f, 0.5f), 22.5f, TabGroup.NeutralRoles)
            .SetParent(CustomRoleSpawnChances[CustomRoles.Ritualist])
            .SetValueFormat(OptionFormat.Seconds);

        RitualMaxCount = new IntegerOptionItem(Id + 11, "RitualMaxCount", new(1, 15, 1), 1, TabGroup.NeutralRoles)
            .SetParent(CustomRoleSpawnChances[CustomRoles.Ritualist])
            .SetValueFormat(OptionFormat.Times);

        CanVent = new BooleanOptionItem(Id + 12, "CanVent", true, TabGroup.NeutralRoles)
            .SetParent(CustomRoleSpawnChances[CustomRoles.Ritualist]);

        HasImpostorVision = new BooleanOptionItem(Id + 13, "ImpostorVision", true, TabGroup.NeutralRoles)
            .SetParent(CustomRoleSpawnChances[CustomRoles.Ritualist]);
    }

    public override void Init() { }

    public override void Add(byte playerId) { }

}
