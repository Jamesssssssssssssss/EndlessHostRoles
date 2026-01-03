using System.Collections.Generic;
using EHR;

public sealed class RoleLimits
{
    // Faction limits
    public int MinImpostors { get; }
    public int MaxImpostors { get; }

    public int MinCrewmates { get; }
    public int MaxCrewmates { get; }

    public int MinNeutrals { get; }
    public int MaxNeutrals { get; }

    public int MinCoven { get; }
    public int MaxCoven { get; }

    // Neutral subcategories
    public int MinNeutralKilling { get; }
    public int MaxNeutralKilling { get; }

    public int MinNeutralNonKilling { get; }
    public int MaxNeutralNonKilling { get; }

    // Alignment limits
    public Dictionary<RoleOptionType, (int Min, int Max)> AlignmentLimits { get; }

    public RoleLimits()
    {
        // Faction limits
        (MinImpostors, MaxImpostors) = ReadMinMax(Team.Impostor);
        (MinCrewmates, MaxCrewmates) = ReadMinMax(Team.Crewmate);
        (MinNeutrals, MaxNeutrals) = ReadMinMax(Team.Neutral);
        (MinCoven, MaxCoven) = ReadMinMax(Team.Coven);

        // Neutral subcategories
        (MinNeutralKilling, MaxNeutralKilling) = ReadSubCategory(RoleOptionType.Neutral_Killing);
        (MinNeutralNonKilling, MaxNeutralNonKilling) = (Options.MinNNKs.GetInt(), Options.MaxNNKs.GetInt());

        // Alignment limits
        AlignmentLimits = ReadAlignmentLimits();
    }

    private static (int Min, int Max) ReadMinMax(Team team)
    {
        try
        {
            var (minSetting, maxSetting) = Options.FactionMinMaxSettings[team];
            int min = minSetting.GetInt();
            int max = maxSetting.GetInt();
            return (min, max);
        }
        catch
        {
            return (0, 0);
        }
    }

    private static (int Min, int Max) ReadSubCategory(RoleOptionType type)
    {
        try
        {
            var entry = Options.RoleSubCategoryLimits[type];
            int min = entry[1].GetInt();
            int max = entry[2].GetInt();
            return (min, max);
        }
        catch
        {
            return (0, 0);
        }
    }

    private static Dictionary<RoleOptionType, (int Min, int Max)> ReadAlignmentLimits()
    {
        var dict = new Dictionary<RoleOptionType, (int Min, int Max)>();

        foreach (var kvp in Options.RoleSubCategoryLimits)
        {
            var type = kvp.Key;
            var values = kvp.Value;

            try
            {
                int min = values[1].GetInt();
                int max = values[2].GetInt();
                dict[type] = (min, max);
            }
            catch
            {
                dict[type] = (0, 0);
            }
        }

        return dict;
    }
}
