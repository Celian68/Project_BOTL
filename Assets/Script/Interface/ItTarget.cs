using BOTL.Data;

public interface ItTarget
{
    void GetDamaged(float damage);
    void Heal(float heal);
    Team GetTeam();
    int GetTeamMultipl();
    float GetLife();
}
