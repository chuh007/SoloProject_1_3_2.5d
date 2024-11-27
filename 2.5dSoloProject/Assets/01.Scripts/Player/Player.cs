using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [Header("FSM")]
    [SerializeField] private EntityStatesSO _playerFSM;

    [field: SerializeField] public PlayerInputSO PlayerInput { get; private set; }

    public EntityState CurrentState => _stateMachine.currentState;

    public float DashPower;

    private EntityMover _mover;
    private PlayerAttackCompo _atkCompo;
    private PlayerDashCompo _dashCompo;

    private StateMachine _stateMachine;

    protected override void AfterInit()
    {
        base.AfterInit();
        _stateMachine = new StateMachine(_playerFSM, this);
        _atkCompo = GetCompo<PlayerAttackCompo>();
        _dashCompo = GetCompo<PlayerDashCompo>();
        PlayerInput.DashEvent += HandleDashEvent;
        PlayerInput.AttackEvent += HandleAttackEvent;

    }

    private void HandleAttackEvent()
    {
        _atkCompo.AttemptAttack();
    }

    private void HandleDashEvent()
    {
        if (_dashCompo.AttemptDash())
        {
            ChangeState("Dash");
        }
    }

    private void Start()
    {
        _stateMachine.Initialize("Idle");
    }

    public EntityState GetState(StateSO state)
        => _stateMachine.GetState(state.stateName);

    public void ChangeState(string newState)
        => _stateMachine.ChangeState(newState);

    private void OnDestroy()
    {
        PlayerInput.DashEvent -= HandleDashEvent;
        PlayerInput.AttackEvent -= HandleAttackEvent;

    }

    private void Update()
    {
        _stateMachine.currentState.Update();
    }
}
