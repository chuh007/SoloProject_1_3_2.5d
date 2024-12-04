using UnityEngine;
using DG.Tweening;

public class Laser : RangeAttack
{
    // �Ӹ��� ������ȭ �Ǿ ���Ϸ�ó�� �������ٰ�

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
        Debug.Log("Laser ����");
        PoolLineRenderer newLine = GameManager.Instance.Pop("LineRenderer") as PoolLineRenderer;
        newLine.InitAndDrawLine(transform.position, transform.right);
    }
}
