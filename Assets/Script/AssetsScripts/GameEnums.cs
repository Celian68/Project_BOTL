namespace BOTL.Data
{
    public enum UnitState { Idle, Moving, Retreating, Attacking, Charging, CancelLoad, Stunned, Dead }
    public enum Team { Team1, Team2 }
    public enum Faction { Human, Elven, NewLand }
    public enum UnitClass { Normal, Hero }
    public enum UnitType { Melee, Ranged, Siege }
    public enum TargetType { Unit, Building }
    public enum Level { Level1, Level2, Level3 }
    public enum BuildingState { New, Damaged, Broken, Destroyed }
    public enum TriggerType { OnStart, OnEnd, OnImpact, OnEffect}
}
