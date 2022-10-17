using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestUp
{
    public class LevelManager : MonoBehaviour
    {
        public float DamageMultiplier { get; private set; } 
        public float HazardRateMultiplier { get; private set; }
        public static LevelManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        void Start()
        {
        
        }

        void Update()
        {
        
        }
    }
}
