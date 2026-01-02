namespace EHR.Modules.RoleSelector;

internal static class RoleSelectionPipeline
{
    public static void Execute(RoleSelectionContext ctx)
    {
        RoleSelectionHooks.RunPreFilter(ctx);
        RolePoolBuilder.Build(ctx); 
        RoleSelectionHooks.RunPreLimits(ctx); 
        RoleCategoryLimiter.Apply(ctx); 
        RoleSelectionHooks.RunPostLimits(ctx); 
        RoleCategoryAssigner.AssignAll(ctx); 
        RoleSelectionHooks.RunPostAssignment(ctx);
    }
}