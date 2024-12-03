using UnityEngine;
using DG.Tweening;

public class Laser : RangeAttack
{
    // 임마는 프리펩화 되어서 페턴런처가 생성해줄겨

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
