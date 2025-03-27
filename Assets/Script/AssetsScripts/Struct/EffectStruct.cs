using Assets.Script.AssetsScripts.Enum;

namespace Assets.Script.AssetsScripts.Struct
{

    [System.Serializable]
    public struct EffectStats
    {
        public TriggerType trigger;
        public float cooldown;
        public int nextUpgradeCost;
        public bool isGlobal;
        public float initialisationTime;
    }

}