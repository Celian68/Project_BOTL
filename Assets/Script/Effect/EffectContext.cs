using System.Collections.Generic;
using Assets.Script.AssetsScripts.Enum;

public class EffectContext
{

    readonly Dictionary<EffectType, AbstractEffectParam> data = new();

    public EffectContext(Dictionary<EffectType, AbstractEffectParam> data)
    {
        if (data != null)
        {
            this.data = data;
        }
    }

    public void SetData(EffectType key, AbstractEffectParam value)
    {
        data[key] = value;
    }

    public AbstractEffectParam GetData(EffectType key)
    {
        if (data.ContainsKey(key))
        {
            return data[key];
        }
        else
        {
            return null;
        }
    }

}
