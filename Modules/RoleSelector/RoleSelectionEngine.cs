using System.Collections.Generic;

namespace EHR.Modules.RoleSelector;

public static class RoleSelectionEngine
{
    public static List<AssignedRoleResult> Run()
    {
        var ctx = new RoleSelectionContext();

        RoleSelectionPipeline.Execute(ctx);

        return RoleSelectionResults.Build(ctx);
    }
}