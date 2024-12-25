using UnityEngine;
using DG.Tweening;
using System.Collections;
using System;

public class Laser : RangeAttack, IPoolable
{
    // �Ӹ��� ������ȭ �Ǿ ���Ϸ�ó�� �������ٰ�

    [Header("Setting Data")]
    [SerializeField] private float Moveduration = 0.5f;


    [SerializeField] private PoolLineRenderer newLine;

    public string PoolName => "Laser";

    public GameObject ObjectPrefab => gameObject;

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
        StartCoroutine(AttackWait());
    }

    private IEnumerator AttackWait()
    {
        yield return new WaitForSeconds(waitTime);
        LaserShoot();
        yield return new WaitForSeconds(hitTime);
    }

    private void LaserShoot()
    {
        Debug.Log("Laser ����");
        PoolLineRenderer newLine = PoolManager.Instance.Pop("LineRenderer") as PoolLineRenderer;
        newLine.InitAndDrawLine(transform.position, transform.TransformPoint(transform.right * 10));
    }
}
