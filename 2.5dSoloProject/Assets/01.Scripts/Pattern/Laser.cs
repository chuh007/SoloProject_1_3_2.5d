using UnityEngine;
using DG.Tweening;

public class Laser : RangeAttack
{
    // �Ӹ��� ������ȭ �Ǿ ���Ϸ�ó�� �������ٰ�

    [Header("Setting Data")]
    [SerializeField] private float duration = 0.5f;

    private void Awake()
    {
        InitializeData();
    }

    private void OnEnable()
    {
        transform.rotation = Quaternion.Euler(0, 0, rotate);
        transform.DOMove(StartMovePos, duration);
    }
}
