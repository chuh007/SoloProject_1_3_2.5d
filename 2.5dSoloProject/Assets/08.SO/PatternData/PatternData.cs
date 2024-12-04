using System.Collections;
using UnityEngine;


[CreateAssetMenu(fileName = "PatternData", menuName = "SO/PatternData")]
public class PatternData : ScriptableObject
{
    public float cycleTime;         // 패턴 지속 시간
    public float attackDelay;       // 다음 공격까지의 딜레이
    public GameObject AttackPrefab; // 공격에 사용할 오브젝트
    public RandomSpownPosType spownType;


}
