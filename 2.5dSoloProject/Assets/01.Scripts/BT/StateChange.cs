using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/StateChange")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "StateChange", message: "change to [state]", category: "Events", id: "a6e1009f8f103ffc08d927657361da81")]
public partial class StateChange : EventChannelBase
{
    public delegate void StateChangeEventHandler(BossState state);
    public event StateChangeEventHandler Event; 

    public void SendEventMessage(BossState state)
    {
        Event?.Invoke(state);
    }

    public override void SendEventMessage(BlackboardVariable[] messageData)
    {
        BlackboardVariable<BossState> stateBlackboardVariable = messageData[0] as BlackboardVariable<BossState>;
        var state = stateBlackboardVariable != null ? stateBlackboardVariable.Value : default(BossState);

        Event?.Invoke(state);
    }

    public override Delegate CreateEventHandler(BlackboardVariable[] vars, System.Action callback)
    {
        StateChangeEventHandler del = (state) =>
        {
            BlackboardVariable<BossState> var0 = vars[0] as BlackboardVariable<BossState>;
            if(var0 != null)
                var0.Value = state;

            callback();
        };
        return del;
    }

    public override void RegisterListener(Delegate del)
    {
        Event += del as StateChangeEventHandler;
    }

    public override void UnregisterListener(Delegate del)
    {
        Event -= del as StateChangeEventHandler;
    }
}

