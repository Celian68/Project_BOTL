using System;
using System.Collections.Generic;
using Assets.Script.AssetsScripts.Enum;
using UnityEngine;

[Serializable]
public class TriggerData
{
    [SerializeField] TriggerType triggerType;
    [SerializeReference, SerializeField] List<AbstractEffect> effects;

    public void ApplyEffects(EffectContext context, TriggerType trigger)
    {
        if (trigger == triggerType)
        {
            foreach (var effect in effects)
            {
                effect.ApplyEffects(context);
            }
        }
    }

    public void AddEffect(AbstractEffect effect)
    {
        int pos = CheckPosition(effect);
        if (pos == -1)
        {
            effects.Add(effect);
        }
        else
        {
            effects[pos] = effect;
        }
    }

    public void RemoveEffect(AbstractEffect effect)
    {
        int pos = CheckPosition(effect);
        if (pos != -1)
        {
            effects.Remove(effect);
        }
    }

    public int CheckPosition(AbstractEffect effect)
    {
        return effects.IndexOf(effect);
    }
}
