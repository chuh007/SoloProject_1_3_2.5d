using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityStatesSO", menuName = "SO/FSM/EntityStatesSO")]
public class EntityStatesSO : ScriptableObject
{
    public List<StateSO> states;

    protected Dictionary<string, StateSO> _statesDictionary;
}