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
        transform.rotation = Quaternion.Euler(0, 0, rotate);
        transform.DOMove(StartMovePos, Moveduration);
    }
}
