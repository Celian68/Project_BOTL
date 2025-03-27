using System.Collections.Generic;
using UnityEngine;

public class MovementEffectParam : AbstractEffectParam
{
    readonly float push;
    Vector2 vector2Value;

    public MovementEffectParam(float push, Vector2 vector2Value, Transform caster, List<Transform> targets, string typeEffect = "Neutre") : base(caster, targets, typeEffect)
    {
        this.push = push;
        this.vector2Value = vector2Value;
    }

    public float GetFloat()
    {
        return push;
    }

    public Vector2 GetVector2()
    {
        return vector2Value;
    }
}