using UnityEngine;

[CreateAssetMenu(fileName = "RangePatternData", menuName = "SO/PatternData/RangePatternData")]
public class RangeAttackData : ScriptableObject
{
    public Vector2 hitSize;
    public float waitTime;
    public float hitTime;
    public int damage;
    public MoveToStartPosType HowToMoveStartPos;
}
public enum MoveToStartPosType
{
    DoMove,
    Move
}