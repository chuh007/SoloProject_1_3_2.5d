using UnityEngine;

public static class Events
{
    public static PopPoolEvent popPoolEvent = new PopPoolEvent();
    public static PushPoolEvent pushPoolEvent = new PushPoolEvent();
}

public class PopPoolEvent : GameEvent
{
    public IPoolable pop;
    public string popName;
}

public class PushPoolEvent : GameEvent
{
    public IPoolable push;
}