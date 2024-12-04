using UnityEngine;

[CreateAssetMenu(fileName = "RangeAttackData", menuName = "SO/AttackData/RangeAttackData")]
public class RangeAttackData : ScriptableObject
{
    public Vector2 hitSize;
    public float waitTime;
    public float hitTime;
    public int damage;
    public MoveToStartPosType HowToMoveStartPos;
    public SetDirectionType WhatIsDirection;
}
