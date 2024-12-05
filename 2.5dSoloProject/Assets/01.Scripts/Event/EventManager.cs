using UnityEngine;
using System;
using System.Collections.Generic;

public class GameEvent
{

}

public static class EventManager
{
    static readonly Dictionary<Type, Action<GameEvent>> s_Events = new Dictionary<Type, Action<GameEvent>>();

    static readonly Dictionary<Delegate, Action<GameEvent>> s_EventLookups = new Dictionary<Delegate, Action<GameEvent>>();

    public static void AddListener<T>(Action<T> evt) where T : GameEvent
    {
        if (s_EventLookups.ContainsKey(evt) == false)
        {
            Action<GameEvent> newAction = (e) => evt(e as T);
            s_EventLookups[evt] = newAction;

            Type evtType = typeof(T);
            if (s_Events.TryGetValue(evtType, out Action<GameEvent> internalAction))
                s_Events[evtType] = internalAction += newAction;
            else
                s_Events[evtType] = newAction;
        }
    }

    public static void RemoveListener<T>(Action<T> evt) where T : GameEvent
    {
        Type evtType = typeof(T);
        if (s_EventLookups.TryGetValue(evt, out Action<GameEvent> action))
        {
            if (s_Events.TryGetValue(evtType, out Action<GameEvent> tempAction))
            {
                tempAction -= action;
                if (tempAction == null)
                    s_Events.Remove(evtType);
                else
                    s_Events[evtType] = tempAction;
            }

            s_EventLookups.Remove(evt);
        }
    }

    public static void RasiseEvent(GameEvent evt)
    {
        if (s_Events.TryGetValue(evt.GetType(), out Action<GameEvent> action))
            action.Invoke(evt);
    }

    public static void Clear()
    {
        s_Events.Clear();
        s_EventLookups.Clear();
    }
}
