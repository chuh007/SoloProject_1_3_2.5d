using UnityEngine;

public abstract class RangeAttack : Attack
{
    [Header("Pattern Data")]
    [SerializeField] protected RangeAttackData PatternDataSO;

    protected Vector2 hitSize;
    protected float waitTime;
    protected float hitTime;
    protected int damage;
    protected MoveToStartPosType type;

    public void InitializeData()
    {
        hitSize = PatternDataSO.hitSize;
        waitTime = PatternDataSO.waitTime;
        hitTime = PatternDataSO.hitTime;
        damage = PatternDataSO.damage;
        type = PatternDataSO.HowToMoveStartPos;
    }

}
