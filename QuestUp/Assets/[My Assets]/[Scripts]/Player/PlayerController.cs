using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace QuestUp
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;

        private PlayerInput _playerInput = null;
        private Rigidbody2D _rigidbody2D = null;
        private PlayerInputActions _playerInputActions = null;
        private Vector2 _moveDirection = Vector2.zero;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _rigidbody2D = GetComponent<Rigidbody2D>();

            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Player.Enable();

            _playerInputActions.Player.Move.performed += MoveInput;
            _playerInputActions.Player.Move.canceled += MoveInput;
        }

        void Update()
        {
            _rigidbody2D.velocity = _moveDirection * _movementSpeed;
        }
        private void MoveInput(InputAction.CallbackContext context)
        {
            _moveDirection = context.ReadValue<Vector2>();
            //Debug.Log(context.ReadValue<Vector2>());
        }


        private void OnEnable()
        {
           _playerInputActions.Enable();
        }

        private void OnDisable()
        {
            _playerInputActions.Disable();
        }
    }   
}
