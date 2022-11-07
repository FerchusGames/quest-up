using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace QuestUp
{
    public class PlayerController : MonoBehaviour
    {
        public bool IsFacingRight { get; private set; }

        [SerializeField] private float _movementSpeed;

        private Animator _animator = null;
        private PlayerInput _playerInput = null;
        private Rigidbody2D _rigidbody2D = null;
        private PlayerInputActions _playerInputActions = null;
        private Vector2 _moveDirection = Vector2.zero;

        private int _ahAxisX = Animator.StringToHash("AxisX");
        private int _ahAxisY = Animator.StringToHash("AxisY");

        private void Awake()
        {
            IsFacingRight = true;

            _animator = GetComponent<Animator>();

            _playerInput = GetComponent<PlayerInput>();
            _rigidbody2D = GetComponent<Rigidbody2D>();

            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Player.Enable();

            _playerInputActions.Player.Move.performed += MoveInput;
            _playerInputActions.Player.Move.canceled += MoveInput;
        }

        private void MoveInput(InputAction.CallbackContext context)
        {
            _moveDirection = context.ReadValue<Vector2>();
            _rigidbody2D.velocity = _moveDirection * _movementSpeed;

            _animator.SetFloat(_ahAxisX, _moveDirection.x);
            _animator.SetFloat(_ahAxisY, _moveDirection.y);

            CheckDirectionToFace(_moveDirection.x > 0);
            //Debug.Log(context.ReadValue<Vector2>());
        }

        private void CheckDirectionToFace(bool isMovingRight)
        {
            if (isMovingRight != IsFacingRight)
            {
                Turn();
            }
        }

        private void Turn()
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

            IsFacingRight = !IsFacingRight;
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
