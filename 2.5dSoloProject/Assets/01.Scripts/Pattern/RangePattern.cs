using UnityEngine;

public abstract class RangePattern : Pattern
{
    protected Vector2 hitSize;
    protected float waitTime;
    protected float hitTime;

    public virtual void Initialize(Entity entity, RangePatternData data)
    {
        hitSize = data.hitSize;
        waitTime = data.waitTime;
        hitTime = data.hitTime;
        onwer = entity;
    }

}
