using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ScatterAttack", story: "[owner] [type] spawn [count] [attack] between [time] [See] [Target]", category: "Action", id: "a649e191040e931498f99a45b2b0b163")]
public partial class ScatterAttackAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Owner;
    [SerializeReference] public BlackboardVariable<AtackType> Type;
    [SerializeReference] public BlackboardVariable<int> Count;
    [SerializeReference] public BlackboardVariable<Attack> Attack;
    [SerializeReference] public BlackboardVariable<float> Time;
    [SerializeReference] public BlackboardVariable<bool> See;
    [SerializeReference] public BlackboardVariable<Transform> Target;
    protected override Status OnStart()
    {

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

