using UnityEngine;

public abstract class Pattern : MonoBehaviour
{
    protected int damage;
    protected Entity onwer;

    public virtual void Initialize(Entity entity, PatternData data)
    {
        onwer = entity;
    }
}
