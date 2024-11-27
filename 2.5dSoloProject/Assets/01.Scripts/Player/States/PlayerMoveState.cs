using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : EntityState
{
    private Player _player;
    private EntityMover _mover;
    public PlayerMoveState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _player = entity as Player;
        _mover = _player.GetCompo<EntityMover>();
    }
    public override void Update()
    {
        base.Update();
        Vector2 moveDir = _player.PlayerInput.InputDirection;
        _mover.SetMovement(moveDir);
        if (Mathf.Approximately(moveDir.x, 0)&& Mathf.Approximately(moveDir.y, 0))
            _player.ChangeState("Idle");
    }
}
