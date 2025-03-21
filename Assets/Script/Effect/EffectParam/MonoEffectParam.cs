public class MonoEffectParam : AbstractEffectParam {
    float floatValues;

    public MonoEffectParam(float param) {
        floatValues = param;
    }

    public float GetFloat() {
        return floatValues;
    } 
}