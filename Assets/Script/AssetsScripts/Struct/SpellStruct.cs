using System.Collections.Generic;

namespace Assets.Script.AssetsScripts.Struct
{
    [System.Serializable]
    public struct SpellStats
    {
        public float range;
        public float cooldown;
        public int baseCost;
        public int nextUpgradeCost;
        public bool isGlobal;
        public float initialisationTime;
        public List<TriggerData> spellTriggers;
    }
}