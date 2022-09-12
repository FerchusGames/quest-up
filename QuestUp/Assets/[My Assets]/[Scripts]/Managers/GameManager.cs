using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestUp
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [field: SerializeField] public int LevelCount { get; private set; } = default;

        private void Awake()
        {
            if (Instance != null)
            {
                GameObject.DestroyImmediate(gameObject);
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if (HealthManager.Instance.CurrentHealth <= 0)
            {
                Debug.Log("GAME OVER");
            }
        }
    }
}
