using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public static PlayerInput PlayerInput;

    public static Vector2 MoveInput { get; set; }

    public static bool isThrowPressed { get; set; }

    public static bool isPausePressed { get; set; }

    private InputAction _moveAction;
    private InputAction _throwAction;
    private InputAction _PauseAction;

    private void Awake()
    {
        PlayerInput = GetComponent<PlayerInput>();

        _moveAction = PlayerInput.actions["Move"];
        _throwAction = PlayerInput.actions["Throw"];
        _PauseAction = PlayerInput.actions["Pause"];
    }

    private void Update()
    {
        MoveInput = _moveAction.ReadValue<Vector2>();

        isThrowPressed = _throwAction.WasPressedThisFrame();

        isPausePressed = _PauseAction.WasPressedThisFrame();
    }
}
