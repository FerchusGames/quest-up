using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

namespace QuestUp
{
    public class PlayerController : MonoBehaviour
    {
        public bool IsFacingRight { get; private set; }

        [SerializeField] private float _movementSpeed = default;
        [SerializeField] private float _maxDashDistance = default;
        [SerializeField] private float _dashDuration = default;
        [SerializeField] private float _dashCoolDown = default;

        private Animator _animator = null;
        private PlayerInput _playerInput = null;
        private Rigidbody2D _rigidbody2D = null;
        private PlayerInputActions _playerInputActions = null;
        private Vector2 _moveDirection = Vector2.zero;
        private Collider2D _collider2D = null;

        private float _dashTimer = default;

        private int _ahAxisX = Animator.StringToHash("AxisX");
        private int _ahAxisY = Animator.StringToHash("AxisY");

        private void Awake()
        {
            _dashTimer = _dashCoolDown;

            IsFacingRight = true;

            _animator = GetComponent<Animator>();

            _playerInput = GetComponent<PlayerInput>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _collider2D = GetComponent<Collider2D>();

            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Player.Enable();

            _playerInputActions.Player.Move.performed += MoveInput;
            _playerInputActions.Player.Move.canceled += MoveInput;

            _playerInputActions.Player.Dash.performed += Dash;
        }

        private void Update()
        {
            UpdateTimers();
        }

        private void OnEnable()
        {
           _playerInputActions.Enable();
        }

        private void OnDisable()
        {
            _playerInputActions.Disable();
        }

        private void UpdateTimers()
        {
            _dashTimer += Time.deltaTime;
        }

        private void Dash(InputAction.CallbackContext context)
        {
            if (_dashTimer >= _dashCoolDown)
            {
                _collider2D.enabled = false;
                _rigidbody2D.DOMove(GetDashPosition(), _dashDuration).OnComplete(OnDashComplete);
                _dashTimer = 0;
            }
        }

        private Vector2 GetDashPosition()
        {
            Vector2 dashMovement = _moveDirection;
            dashMovement *= _maxDashDistance;

            Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);

            return currentPos + dashMovement;
        }

        private void OnDashComplete()
        {
            _collider2D.enabled = true;
        }

        private void MoveInput(InputAction.CallbackContext context)
        {
            _moveDirection = context.ReadValue<Vector2>();
            _rigidbody2D.velocity = _moveDirection * _movementSpeed;

            _animator.SetFloat(_ahAxisX, _moveDirection.x);
            _animator.SetFloat(_ahAxisY, _moveDirection.y);

            CheckDirectionToFace(_moveDirection.x > 0);
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
    }   
}
