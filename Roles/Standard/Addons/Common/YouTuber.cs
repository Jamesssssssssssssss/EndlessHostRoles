namespace EHR.Roles;

internal class YouTuber : AddonBase
{
    public override AddonTypes Type => AddonTypes.Mixed;

    public override void SetupCustomOption()
    {
        Options.SetupAdtRoleOptions(18800, CustomRoles.Youtuber, canSetNum: true, tab: TabGroup.Addons, teamSpawnOptions: true);
    }
}