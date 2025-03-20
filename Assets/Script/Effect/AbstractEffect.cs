using UnityEngine;
using BOTL.Data;

[System.Serializable]
public abstract class AbstractEffect
{

    protected EffectType type; 
    protected EffectBlob parameters = null;
    public virtual void ApplyEffect(EffectContext context) {
        parameters = context.GetData(type);
    }

    public EffectType GetEffectType()
    {
        return type;
    }
}