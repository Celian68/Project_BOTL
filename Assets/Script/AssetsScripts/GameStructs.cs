namespace BOTL.Data
{
    [System.Serializable]
    public struct UnitStats
    {
        public float damage;
        public float moveSpeed;
        public float attackRange;
        public float attackSpeed;
        public int baseCost;
        public float spawnTime;
    }

    [System.Serializable]
    public struct TargetStats
    {
        public int maxLife;
        public int nextUpgradeCost;
    }

    [System.Serializable]
    public struct CastleStats
    {
        public int maxResource;
    }

    [System.Serializable]
    public struct ProducerStats
    {
        public float resourcePerSec;
    }

    [System.Serializable]
    public struct SpellStats
    {
        public float range;
        public float cooldown;
        public int nextUpgradeCost;
        public bool isGlobal;
        public float initialisationTime;
    }

    [System.Serializable]
    public struct BuildingStats
    {
        public int nextUpgradeCost;
    }

}
