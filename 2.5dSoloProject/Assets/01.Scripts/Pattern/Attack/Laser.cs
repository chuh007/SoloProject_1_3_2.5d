using UnityEngine;
using DG.Tweening;
using System.Collections;
using System;

public class Laser : RangeAttack, IPoolable
{
    // 임마는 프리펩화 되어서 페턴런처가 생성해줄겨

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
        PushLaser();
    }

    private void PushLaser()
    {
        newLine.ResetItem();
        PushPoolEvent evt = Events.pushPoolEvent;
        evt.push = newLine;
        EventManager.RasiseEvent(evt);
        newLine = null;
        evt.push = this;
        EventManager.RasiseEvent(evt);
    }

    private void LaserShoot()
    {
        Debug.Log("Laser 슈웃");
        PopPoolEvent evt = Events.popPoolEvent;
        evt.popName = "LineRenderer";
        EventManager.RasiseEvent(evt);
        newLine = evt.pop as PoolLineRenderer;
        newLine.InitAndDrawLine(transform.position, transform.TransformPoint(transform.right * 10));
    }

    
}
