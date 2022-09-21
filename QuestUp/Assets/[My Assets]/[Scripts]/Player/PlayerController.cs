using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace QuestUp
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerInputActions _playerControls;
        private CharacterController _characterController;
        private InputAction _moveInputAction;

        Vector2 _moveDirection = Vector2.zero;

        private void Awake()
        {
            _playerControls = new PlayerInputActions();
            _characterController = GetComponent<CharacterController>();
        }

        private void OnEnable()
        {
            _moveInputAction = _playerControls.Battle.Move;
        }

        private void OnDisable()
        {
            _moveInputAction.Disable();
        }

        void Update()
        {
            _moveDirection = _moveInputAction.ReadValue<Vector2>();
            Debug.Log(_moveDirection);
            _characterController.Move(_moveDirection * 1000);
        }
    }   
}
