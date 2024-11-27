using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : EntityState
{
    private Player _player;
    private EntityMover _mover;
    public PlayerIdleState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _player = entity as Player;
        _mover = _player.GetCompo<EntityMover>();
    }

    public override void Enter()
    {
        base.Enter();
        _mover.RbCompo.linearVelocity = Vector2.zero;
    }
    public override void Update()
    {
        base.Update();
        Vector2 moveDir = _player.PlayerInput.InputDirection;
        if(Mathf.Abs(moveDir.x) > 0 || Mathf.Abs(moveDir.y) > 0) 
            _player.ChangeState("Move");
    }
}
