using EHR.Roles;

namespace EHR.Gamemodes;

public abstract class GamemodeBase
{
    public virtual CustomRoles? GamemodeRole => null;
}