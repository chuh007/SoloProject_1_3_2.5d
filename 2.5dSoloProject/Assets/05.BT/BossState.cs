using Unity.Behavior;
using UnityEngine;

[BlackboardEnum]
public enum BossState
{
    Laser1, 
    Laser2, 
    Bullet1, 
    Bullet2, 
    Pattern5, 
    Wait
}

[BlackboardEnum]
public enum AtackType
{
    Top,
    Bottom,
    Left,
    Right,
    RandomOutBox,
    RandomInBox
}
