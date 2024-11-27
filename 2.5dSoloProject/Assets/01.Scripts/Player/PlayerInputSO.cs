using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlayerInputSO", menuName = "SO/PlayerInputSO")]
public class PlayerInputSO : ScriptableObject, Controls.IPlayerInputActions
{
    public event Action MoveEvent;
    public event Action AttackEvent;
    public event Action DashEvent;

    public Vector2 InputDirection { get; private set; }

    private Controls _controls;

    private void OnEnable()
    {
        if(_controls == null)
        {
            _controls = new Controls();
            _controls.PlayerInput.SetCallbacks(this);
        }
        _controls.Enable();
    }
    private void OnDisable()
    {
        _controls.Disable();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            AttackEvent?.Invoke();
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            DashEvent?.Invoke();
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        InputDirection = context.ReadValue<Vector2>();
        MoveEvent?.Invoke();
    }
}
