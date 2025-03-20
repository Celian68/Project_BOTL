using BOTL.Data;
using UnityEngine;

[System.Serializable]
public class DamageEffect : AbstractEffect
{
    public float damage;

    public DamageEffect(float damage)
    {
        this.damage = damage;
        type = EffectType.Damage;
    }

    public DamageEffect() {
        type = EffectType.Damage;
    }

    public override void ApplyEffect(EffectContext context)
    {
        base.ApplyEffect(context);
        if (parameters.NbFloat() > 0) {
            damage = parameters.GetFloat(0);
        }
        foreach (var enemyTarget in context.GetTargets()) {
            enemyTarget.GetComponent<ItTarget>()?.GetDamaged(damage);
            Debug.Log("Damage dealt: " + damage);
        }
    }
}