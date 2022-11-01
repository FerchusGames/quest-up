using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestUp
{
    public class MoveRight : MonoBehaviour
    {
        //[SerializeField] private ProjectileSO _projectileSO = null;
        private float _movementSpeed = default;

        private void Start()
        {
         //   _movementSpeed = _projectileSO.Speed;
        }

        void Update()
        {
            transform.Translate(Vector2.right * _movementSpeed * Time.deltaTime); 
        }
    }
}
