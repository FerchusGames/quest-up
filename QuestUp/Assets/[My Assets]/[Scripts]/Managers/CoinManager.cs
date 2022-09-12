using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestUp
{
    public class CoinManager : MonoBehaviour
    {
        public static CoinManager Instance { get; private set; }

        public int _coins = default;
        public int _coinMultiplier = 1;    

        private void Awake()
        {
            if(Instance != null)
            {
                GameObject.DestroyImmediate(gameObject);
            }
            Instance = this;   
            DontDestroyOnLoad(gameObject);
        }
    
        public int GetCoins()
        {
            return _coins;
        }
    }
}
