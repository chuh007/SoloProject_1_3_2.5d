using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    protected Entity onwer;
    protected Vector3 StartMovePos;
    protected float rotate;

    public void ResetItem()
    {
        transform.rotation = Quaternion.identity;
        transform.position = Vector3.zero;
    }

    public void Initialize(Vector3 StartMovePos, float rotate)
    {
        this.StartMovePos = StartMovePos;
        this.rotate = rotate;
    }

    public abstract void ReadyAttack();

}
public enum MoveToStartPosType
{
    DoMove,
    Move
}

public enum SetDirectionType
{
    Random,
    SeeTarget,
    Up,
    Down,
    Left,
    Right
}
