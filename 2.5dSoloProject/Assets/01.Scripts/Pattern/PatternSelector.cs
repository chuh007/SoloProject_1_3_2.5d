using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PatternSelector : MonoBehaviour, IEntityComponent
{
    [SerializeField] private List<Pattern> usePatternList;

    private Entity onwer;


    public void Initialize(Entity entity)
    {
        onwer = entity;
    }



}
