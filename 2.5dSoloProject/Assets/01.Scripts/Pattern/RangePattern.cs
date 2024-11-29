using UnityEngine;

public class RangePattern : Pattern
{
    protected Vector2 hitSize;
    protected float waitTime;
    protected float hitTime;

    public override void Initialize(Entity entity, PatternData data)
    {
        base.Initialize(entity, data);
    }

}
