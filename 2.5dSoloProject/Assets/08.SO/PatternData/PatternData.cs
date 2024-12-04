using System.Collections;
using UnityEngine;


[CreateAssetMenu(fileName = "PatternData", menuName = "SO/PatternData")]
public class PatternData : ScriptableObject
{
    public float cycleTime;         // ���� ���� �ð�
    public float attackDelay;       // ���� ���ݱ����� ������
    public GameObject AttackPrefab; // ���ݿ� ����� ������Ʈ
    public RandomSpownPosType spownType;


}
