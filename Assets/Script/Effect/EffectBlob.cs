using System.Collections.Generic;
using UnityEngine;

public class EffectBlob {
    List<float> floatValues = new();
    Vector2 vector2Value = new();
    GameObject gameObjectValue = null;
    string typeEffect = "Neutre";

    public void SetFloat(List<float> values) {
        floatValues = values;
    }

    public float GetFloat(int index) {
        return floatValues[index];
    }

    public int NbFloat() {
        return floatValues.Count;
    }
    
    public void SetVector2(Vector2 value) {
        vector2Value = value;
    }

    public Vector2 GetVector2() {
        return vector2Value;
    }

    public void SetGameObject(GameObject value) {
        gameObjectValue = value;
    }

    public GameObject GetGameObject() {
        return gameObjectValue;
    }

    public string GetTypeEffect() {
        return typeEffect;
    }  
}