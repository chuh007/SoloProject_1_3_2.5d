using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "GetCompoFromEntity", story: "get compo from [entity]", category: "Action", id: "339133e245ef84d0368727ffe7b4c422")]
public partial class GetCompoFromEntityAction : Action
{
    [SerializeReference] public BlackboardVariable<BTEnemy> Entity;

    protected override Status OnStart()
    {
        BTEnemy enemy = Entity.Value;
        return Status.Success;
    }
}

