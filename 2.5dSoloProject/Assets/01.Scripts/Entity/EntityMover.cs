using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMover : MonoBehaviour, IEntityComponent
{
    [Header("Move Settings")]
    [SerializeField] private float _moveSpeed;

    public Vector2 Velocity => _rbCompo.linearVelocity;

    public float SpeedMultplier { get; set; } = 1f;
    public bool CanManualMove { get; set; } = true;

    private Entity _entity;
    private EntityRenderer _renderer;
    private Rigidbody2D _rbCompo;

    public Rigidbody2D RbCompo
    {
        get
        {
            return _rbCompo;
        }
        set
        {
            _rbCompo = value;
        }
    }

    private Vector2 _movement;

    public void Initialize(Entity entity)
    {
        _entity = entity;
        _renderer = _entity.GetComponentInChildren<EntityRenderer>();
        _rbCompo = GetComponentInParent<Rigidbody2D>();
    }
    public void SetMovement(Vector2 movement)
    {
        _movement = movement;
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }
    private void MoveCharacter()
    {
        if (CanManualMove)
        {
            _rbCompo.linearVelocity = _movement * _moveSpeed * SpeedMultplier;
            // _rbCompo.linearVelocityX = _xMovement * _moveSpeed * SpeedMultuplier;
            // _renderer.FlipController(_xMovement);
        }

        // _renderer.SetParam(_ySpeedParam, _rbCompo.linearVelocityY);
    }
}
