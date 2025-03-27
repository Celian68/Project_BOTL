using System.Collections.Generic;

namespace Assets.Script.AssetsScripts.Struct
{
    [System.Serializable]
    public struct UnitStats
    {
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
        public List<TriggerData> targetTriggers;
    }

    [System.Serializable]
    public struct CastleStats
    {
        public int maxResource;
    }
}