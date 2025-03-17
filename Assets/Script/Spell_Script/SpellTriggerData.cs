using System.Collections.Generic;
using BOTL.Data;

[System.Serializable]
public class SpellTriggerData
{
    public TriggerType triggerType;
    public List<SpellEffect> effects;
}
