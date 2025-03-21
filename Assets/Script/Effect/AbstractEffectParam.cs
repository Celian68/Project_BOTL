
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEffectParam {
    readonly string typeEffect;

    readonly List<Transform> targets;
    readonly Transform caster;

    public AbstractEffectParam(string typeEffect = "Neutre") {
        this.typeEffect = typeEffect;
    }

    public string GetTypeEffect() {
        return typeEffect;
    }  
}