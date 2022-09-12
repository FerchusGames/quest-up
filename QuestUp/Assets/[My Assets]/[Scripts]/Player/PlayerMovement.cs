using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D _rb;

    public float _moveSpeed = 5f;

    [SerializeField] Joystick _joystick;

    Vector2 _movement;

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
