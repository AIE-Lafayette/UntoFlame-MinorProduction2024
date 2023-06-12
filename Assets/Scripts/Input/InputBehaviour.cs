using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputBehaviour : MonoBehaviour
{
    private PlayerMovementBehaviour _moveBehaviour;

    private PlayerActions _playerActions;


    private void Awake()
    {
        _playerActions = new PlayerActions();
        _playerActions.Character.Movement.performed += Move;
        _playerActions.Character.Jump.performed += Jump;

        _playerActions.Character.Pause.performed += Pause;
    }

    private void OnEnable()
    {
        _playerActions.Enable();
    }

    private void OnDisable()
    {
        _playerActions.Disable();
    }

    private void Pause(InputAction.CallbackContext context)
    {
        UIManager.Instance.Pause();
    }

    private void Move(InputAction.CallbackContext context)
    {
        float moveDirection = context.ReadValue<float>();
        _moveBehaviour.SetMoveDirection(new Vector3(moveDirection, 0, 0));
    }

    private void Jump(InputAction.CallbackContext context)
    {
        float jump = context.ReadValue<float>();
        _moveBehaviour.Jump();
    }

    // Start is called before the first frame update
    void Start()
    {
        _moveBehaviour = GetComponent<PlayerMovementBehaviour>();
    }

  
}
