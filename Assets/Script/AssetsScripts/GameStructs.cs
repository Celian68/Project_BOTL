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

}
