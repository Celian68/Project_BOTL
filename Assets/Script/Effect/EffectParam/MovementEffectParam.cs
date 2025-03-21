using UnityEngine;

public class MovementEffectParam : AbstractEffectParam {
    float push;
    Vector2 vector2Value;

    public MovementEffectParam(float push, Vector2 vector2Value) {
        this.push = push;
        this.vector2Value = vector2Value;
    }

    public float GetFloat() {
        return push;
    }
    
    public Vector2 GetVector2() {
        return vector2Value;
    }
}