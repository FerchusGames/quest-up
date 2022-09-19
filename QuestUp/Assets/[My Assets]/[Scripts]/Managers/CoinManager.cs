using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestUp
{
    public class CoinManager : MonoBehaviour
    {
        public static CoinManager Instance { get; private set; }

        [field: SerializeField] public int Coins { get; private set; }
        [field: SerializeField] public int CoinMultiplier { get; private set; } = 1;    

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
    }
}
