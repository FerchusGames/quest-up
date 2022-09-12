using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestUp
{
    public class PlayerMovement : MonoBehaviour
    {
        public float _moveSpeed = default;

        [SerializeField] private Joystick _joystick = null;

        private Rigidbody2D _rb = null;
        private Vector2 _movement = default;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
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
            _rb.MovePosition(_rb.position + _movement * _moveSpeed * Time.fixedDeltaTime);
        }
    }
}
