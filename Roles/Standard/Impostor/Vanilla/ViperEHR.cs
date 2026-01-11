using static EHR.Options;

namespace EHR.Roles;

internal class ViperEHR : RoleBase
{
    public static OptionItem ViperDissolveTime;

    public override bool IsEnable => false;

    public override CustomRoles RoleId => CustomRoles.ViperEHR;
    public override CustomGamemodes GamemodeId => CustomGamemodes.Standard;

    public override void Add(byte playerId) { }
    public override void Init() { }

    public override void SetupCustomOption()
    {
        SetupRoleOptions(410, TabGroup.ImpostorRoles, CustomRoles.ViperEHR);

        ViperDissolveTime =
            new FloatOptionItem(412, "ViperDissolveTime", new(0f, 60f, 0.5f), 10f, TabGroup.ImpostorRoles)
                .SetParent(CustomRoleSpawnChances[CustomRoles.ViperEHR])
                .SetValueFormat(OptionFormat.Seconds);
    }
}
