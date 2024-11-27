using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : EntityState
{
    private const float DASH_DELAY_TIME = 0.2f;
    protected Player _player;
    protected EntityMover _mover;
    private float _originallyGravityScale = 1f;
    private float dashStartTime;

    public PlayerDashState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _player = entity as Player;
        _mover = _player.GetCompo<EntityMover>();
    }

    public override void Enter()
    {
        base.Enter();
        _mover.CanManualMove = false;
        _mover.RbCompo.AddForce(_player.PlayerInput.InputDirection * _player.DashPower, ForceMode2D.Impulse);
        _originallyGravityScale = _mover.RbCompo.gravityScale;
        _mover.RbCompo.gravityScale = 0;
        dashStartTime = Time.time;
    }

    public override void Update()
    {
        base.Update();
        if (dashStartTime + DASH_DELAY_TIME < Time.time)
        {
            _player.ChangeState("Move");
        }
    }

    public override void Exit()
    {
        _mover.CanManualMove = true;
        base.Exit();
        _mover.RbCompo.gravityScale = _originallyGravityScale;
    }
}
