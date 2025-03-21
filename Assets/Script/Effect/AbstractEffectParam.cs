
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEffectParam {
    readonly string typeEffect;

    readonly List<Transform> targets;
    readonly Transform caster;

    public AbstractEffectParam(Transform caster, List<Transform> targets, string typeEffect) {
        this.typeEffect = typeEffect;
        this.caster = caster;
        this.targets = targets;
    }

    public string GetTypeEffect() {
        return typeEffect;
    } 

    public Transform GetCaster() {
        return caster;
    }

    public List<Transform> GetTargets() {
        return targets;
    } 
}