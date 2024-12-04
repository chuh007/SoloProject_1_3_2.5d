using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PatternSelector : MonoBehaviour, IEntityComponent
{
    [SerializeField] private List<PatternData> usePatternList;

    public UnityEvent<PatternData> SetPattern;

    private Entity onwer;

    public void Initialize(Entity entity)
    {
        onwer = entity;
    }

    public void PatternRandomSellect()
    {
        int rand = Random.Range(0, usePatternList.Count);
        SetPattern?.Invoke(usePatternList[rand]);
        Debug.Log(rand);
    }

}
