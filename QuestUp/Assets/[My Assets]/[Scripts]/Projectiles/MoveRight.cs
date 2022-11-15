using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestUp
{
    public class MoveRight : MonoBehaviour
    {
        private float _movementSpeed = default;

        void Update()
        {
            transform.Translate(Vector2.right * _movementSpeed * Time.deltaTime); 
        }
    }
}
