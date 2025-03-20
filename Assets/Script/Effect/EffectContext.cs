using System.Collections.Generic;
using BOTL.Data;
using UnityEngine;

public class EffectContext {
    readonly List<Transform> targets;
    readonly Transform caster;
    readonly Dictionary<EffectType, EffectBlob> data = new();

    public EffectContext(Transform caster, List<Transform> targets, Dictionary<EffectType, EffectBlob> data) {
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

    public void SetData(EffectType key, EffectBlob value) {
        data[key] = value;
    }

    public EffectBlob GetData(EffectType key) {
        if (data.ContainsKey(key)) {
            return data[key];
        }else{
            return new EffectBlob();
        }
    }

}
