using System.Collections.Generic;
using BOTL.Data;
using UnityEngine;

public class EffectContext {
    
    readonly Dictionary<EffectType, AbstractEffectParam> data = new();

    public EffectContext(Transform caster, List<Transform> targets, Dictionary<EffectType, AbstractEffectParam> data) {
        this.caster = caster;
        this.targets = targets;
        if (data != null) {
            this.data = data;
        }
    }

    public Transform GetCaster() {
        return caster;
    }

    public List<Transform> GetTargets() {
        return targets;
    }

    public void SetData(EffectType key, AbstractEffectParam value) {
        data[key] = value;
    }

    public AbstractEffectParam GetData(EffectType key) {
        if (data.ContainsKey(key)) {
            return data[key];
        }else{
            return null;
        }
    }

}
