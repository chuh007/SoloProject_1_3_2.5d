using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    protected Entity onwer;
    protected Vector3 StartMovePos;
    protected float rotate;

    public void Initialize(Vector3 StartMovePos, float rotate)
    {
        this.StartMovePos = StartMovePos;
        this.rotate = rotate;
    }

    public abstract void ReadyAttack();


}
