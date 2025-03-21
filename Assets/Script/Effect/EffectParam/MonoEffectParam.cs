using System.Collections.Generic;
using UnityEngine;

public class MonoEffectParam : AbstractEffectParam {
    float floatValues;

    public MonoEffectParam(float param, Transform caster, List<Transform> targets, string typeEffect = "Neutre") : base(caster, targets, typeEffect) {
        floatValues = param;
    }

    public float GetFloat() {
        return floatValues;
    } 
}