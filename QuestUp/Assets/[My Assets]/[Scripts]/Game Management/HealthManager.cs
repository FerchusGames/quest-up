using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance { get; private set; }

    public int _maxHealth;
    public int _currentHealth;

    private void Awake()
    {
        if (Instance != null)
        {
            GameObject.DestroyImmediate(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public int GetHealth()
    {
        return _currentHealth;
    }
}
