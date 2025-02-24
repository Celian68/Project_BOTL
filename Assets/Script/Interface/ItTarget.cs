using BOTL.Enum;

public interface ItTarget
{
    void GetDamaged(float damage);
    void Heal(float heal);
    Team GetTeam();
    float GetTeamMultipl();
    float GetLife();
}
