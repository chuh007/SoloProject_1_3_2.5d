using UnityEngine;
using DG.Tweening;

public class Laser : RangeAttack
{
    // 임마는 프리펩화 되어서 페턴런처가 생성해줄겨

    [Header("Setting Data")]
    [SerializeField] private float Moveduration = 0.5f;

    private void Awake()
    {
        InitializeData();
    }


    public override void ReadyAttack()
    {
        if(moveType == MoveToStartPosType.DoMove)
        {
            transform.DOMove(StartMovePos, Moveduration);
            transform.DORotate(new Vector3(0, 0, rotate), Moveduration);
        }
        else
        {
            transform.position = StartMovePos;
            transform.rotation = Quaternion.Euler(0, 0, rotate);
        }
    }

    private void LaserShoot()
    {
        Debug.Log("Laser 슈웃");
        PoolLineRenderer newLine = GameManager.Instance.Pop("LineRenderer") as PoolLineRenderer;
        newLine.InitAndDrawLine(transform.position, transform.right);
    }
}
