using BOTL.Data;
using UnityEngine;

[System.Serializable]
public class PushEffect : AbstractEffect
{
    public float pushForce;

    public PushEffect(float pushForce)
    {
        this.pushForce = pushForce;
        type = EffectType.Push;
    }

    public PushEffect() {
        type = EffectType.Push;
    }

    public override void ApplyEffect(EffectContext context)
    {
        base.ApplyEffect(context);
        if (parameters.NbFloat() > 0) {
            pushForce = parameters.GetFloat(0);
        }
        foreach (var enemyTarget in context.GetTargets()) {
            enemyTarget.GetComponent<Rigidbody2D>().AddForce(parameters.GetVector2() * pushForce, ForceMode2D.Impulse);
            Debug.Log("Push dealt: " + pushForce);
        }
    }
}