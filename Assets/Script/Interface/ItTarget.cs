using Assets.Script.AssetsScripts.Enum;

public interface ITTarget
{
    void GetDamaged(float damage);
    void Heal(float heal);
    Team GetTeam();
    int GetTeamMultipl();
    float GetLife();
}
