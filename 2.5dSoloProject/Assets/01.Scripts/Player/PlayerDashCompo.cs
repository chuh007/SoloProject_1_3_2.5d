using UnityEngine;

public class PlayerDashCompo : MonoBehaviour, IEntityComponent
{
    [SerializeField] private float _dashCooldown;
    [SerializeField] private StateSO _dashState;

    private Player _player;
    private float _lastDashTime;

    public void Initialize(Entity entity)
    {
        _player = entity as Player;
    }

    public bool AttemptDash()
    {
        if (_player.CurrentState == _player.GetState(_dashState)) return false;
        if (_lastDashTime + _dashCooldown > Time.time) return false;
        _lastDashTime = Time.time;
        return true;
    }
}
