namespace BOTL.Struct
{
    [System.Serializable]
    public struct UnitStats
    {
        public float damage;
        public float moveSpeed;
        public float unitRange;
        public float attackSpeed;
        public float baseCost;
    }

    [System.Serializable]
    public struct TargetStats
    {
        public float maxLife;
        public int nextUpgradeCost;
    }

    [System.Serializable]
    public struct CastleStats
    {
        public float maxResource;
    }

    [System.Serializable]
    public struct ProduceurStats
    {
        public float resourcePerSec;
    }

}
