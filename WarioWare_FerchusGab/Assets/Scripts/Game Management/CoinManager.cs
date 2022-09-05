using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    public int coins;
    [SerializeField] int coinMultiplier = 1;

    private void Awake()
    {
        if(instance != null)
        {
            GameObject.DestroyImmediate(gameObject);
        }
        instance = this;   
        DontDestroyOnLoad(gameObject);
    }
    
    public int GetCoins()
    {
        return coins;
    }
}
