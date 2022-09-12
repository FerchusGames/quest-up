using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTransitionOnStart : MonoBehaviour
{
    LoadTransitionOnStart instance;
    private void Awake()
    {
        if (instance != null)
        {
            GameObject.DestroyImmediate(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        { 
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
        }
    }
}
