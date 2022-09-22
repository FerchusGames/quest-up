using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace QuestUp
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerInput _playerInput = null;
        private CharacterController _characterController = null;
        private PlayerInputActions _playerInputActions = null;
        private Vector2 _moveDirection = Vector2.zero;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _characterController = GetComponent<CharacterController>();

            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Player.Enable();
            _playerInputActions.Player.Move.performed += Move_performed;
        }

        private void Move_performed(InputAction.CallbackContext context)
        {
            Debug.Log(context.ReadValue<Vector2>());
        }

        private void OnEnable()
        {
           _playerInputActions.Enable();
        }

        private void OnDisable()
        {
            _playerInputActions.Disable();
        }

        void Update()
        {
            _characterController.Move(_moveDirection * 1000);
        }
    }   
}
