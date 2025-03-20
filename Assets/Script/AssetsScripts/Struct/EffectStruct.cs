namespace BOTL.Data
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