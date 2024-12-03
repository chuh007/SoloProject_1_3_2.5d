using System.Collections;
using UnityEngine;

public abstract class Pattern : MonoBehaviour
{
    protected float cycleTime;         // 패턴 지속 시간
    protected float attackDelay;       // 다음 공격까지의 딜레이
    protected GameObject AttackPrefab; // 공격에 사용할 오브젝트
    protected bool isCycleTime = false;// 패턴 지속 시간인가?

    protected virtual void StartPattern()
    {
        StartCoroutine(PatternAttack());
    }

    protected virtual IEnumerator PatternAttack()
    {
        while (isCycleTime)
        {
            yield return new WaitForSeconds(attackDelay);
            Instantiate(AttackPrefab); // TODO 풀메니저로 전환
        }
    }

}
