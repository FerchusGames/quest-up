using UnityEngine;

namespace QuestUp
{
    public class PlayerMovement : MonoBehaviour
    {
        public float _moveSpeed = default;

        [SerializeField] private Joystick _joystick = null;

        private Rigidbody2D _rigidBody2D = null;
        private Vector2 _movement = default;

        private void Start()
        {
            _rigidBody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _movement.x = _joystick.Horizontal;
            _movement.y = _joystick.Vertical;
        }

        private void FixedUpdate()
        {
            _movement.Normalize();
            MovePlayer();
        }

        private void MovePlayer()
        {
            _rigidBody2D.MovePosition(_rigidBody2D.position + _movement * _moveSpeed * Time.fixedDeltaTime);
        }
    }
}
