using System.Collections;
using UnityEngine;

public abstract class Pattern : MonoBehaviour
{
    protected float cycleTime;         // ���� ���� �ð�
    protected float attackDelay;       // ���� ���ݱ����� ������
    protected GameObject AttackPrefab; // ���ݿ� ����� ������Ʈ
    protected bool isCycleTime = false;// ���� ���� �ð��ΰ�?

    protected virtual void StartPattern()
    {
        StartCoroutine(PatternAttack());
    }

    protected virtual IEnumerator PatternAttack()
    {
        while (isCycleTime)
        {
            yield return new WaitForSeconds(attackDelay);
            Instantiate(AttackPrefab); // TODO Ǯ�޴����� ��ȯ
        }
    }

}
