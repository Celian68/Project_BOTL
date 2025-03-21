using UnityEngine;
using BOTL.Data;

[System.Serializable]
public abstract class AbstractEffect
{
    protected EffectType type; 

    public AbstractEffect(EffectType type)
    {
        this.type = type;
    }  

    public void ApplyEffects(EffectContext context) {
        ApplyEffect(context.GetData(type));

    }

    public abstract void ApplyEffect(AbstractEffectParam param);

    public EffectType GetEffectType()
    {
        return type;
    }
}