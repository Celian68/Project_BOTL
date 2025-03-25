using BOTL.Data;
using UnityEngine;

[System.Serializable]
public class DamageEffect : AbstractEffect
{
    public float damage;

    public DamageEffect(float damage) : base(EffectType.Damage)
    {
        this.damage = damage;
    }

    public DamageEffect() : base(EffectType.Damage) {}

    public override void ApplyEffect(AbstractEffectParam param)
    {
        MonoEffectParam castParam = param as MonoEffectParam;
        if (castParam.GetFloat() != -1) {
            damage = castParam.GetFloat();
        }
        foreach (var enemyTarget in castParam.GetTargets()) {
            enemyTarget.GetComponent<ItTarget>()?.GetDamaged(damage);
        }
    }
}