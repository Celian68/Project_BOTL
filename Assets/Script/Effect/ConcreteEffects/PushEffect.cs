using BOTL.Data;
using UnityEngine;

[System.Serializable]
public class PushEffect : AbstractEffect
{
    public float pushForce;

    public PushEffect(float pushForce) : base(EffectType.Push)
    {
        this.pushForce = pushForce;
    }

    public PushEffect() : base(EffectType.Push) {}

    public override void ApplyEffect(AbstractEffectParam param)
    {
        MovementEffectParam castParam = param as MovementEffectParam;
        if (castParam.GetFloat() != -1) {
            pushForce = castParam.GetFloat();
        }
        foreach (var enemyTarget in castParam.GetTargets()) {
            enemyTarget.GetComponent<Rigidbody2D>().AddForce(castParam.GetVector2() * pushForce, ForceMode2D.Impulse);
            Debug.Log("Push dealt: " + pushForce);
        }
    }
}